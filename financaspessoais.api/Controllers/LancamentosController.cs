using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancasPessoais.Domain.UseCases.Lancamentos;
using FinancasPessoais.Domain.UseCases.Lancamentos.Commands;
using FinancasPessoais.Domain.UseCases.Lancamentos.Contracts;
using FinancasPessoais.Domain.UseCases.Lancamentos.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace financaspessoais.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LancamentosController : ControllerBase
    {
        private readonly ICreateLancamento _createLancamento;
        private readonly IGetLancamento _getLancamento;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public LancamentosController(ICreateLancamento createLancamento,IGetLancamento getLancamento)
        {
            _createLancamento = createLancamento;
            _getLancamento = getLancamento;
        }

        [HttpPost]
        public async Task<Result<string>> Post(List<CreateLancamentoCommand> comando)
        {
            try
            {
                
                var result = await _createLancamento.HandleAsync(comando.Select(x => x.ToEntityDomain()).ToList());

                if(result.Success)
                {
                    return Result<string>.Succeeded(200,result.Message,"");
                }
                else
                {
                    return Result<string>.Failed(400,result.Value[0],"Erro na requisição, tente novamente mais tarde.");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<Result<GetLancamentosMesComTotalizacaoResult>> Get(int ano,int mes)
        {
            try
            {
                var result = await _getLancamento.GetLancamentosPorMes(ano,mes);

                if(result.Success)
                {
                    return Result<GetLancamentosMesComTotalizacaoResult>.Succeeded(200,result.Message,result.Value);
                }
                else
                {
                    return Result<GetLancamentosMesComTotalizacaoResult>.Failed(200,result.Message,null);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
