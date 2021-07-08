using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancasPessoais.Domain.Entities;
using FinancasPessoais.Domain.IEntities;
using FinancasPessoais.Domain.IRepositories;
using FinancasPessoais.Domain.UseCases.Lancamentos.Contracts;
using FinancasPessoais.Domain.UseCases.Lancamentos.Results;

namespace FinancasPessoais.Domain.UseCases.Lancamentos
{
    public class CreateLancamento : ICreateLancamento
    {
        private readonly ILancamentoRepository _lancamentoRepository;

        public CreateLancamento(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task<Result<List<string>>> HandleAsync(Lancamento lancamento)
        {
            try
            {
                var notificacoes = lancamento.Validate();

                if (notificacoes.Count > 0)
                {
                   return Result<List<string>>.Failed(400, "O lançamento é invalido. Por favor, corrija os dados.", notificacoes);
                }

                var lancamentoSalvo = await _lancamentoRepository.Save(lancamento);

                return Result<List<string>>.Succeeded(200, $"O lançamento foi salvo com sucesso. Id: {lancamentoSalvo.GetId()}");

            }
            catch(Exception ex)
            {
                var mensagem = new List<string>();
                mensagem.Add(ex.Message);
                return Result<List<string>>.Failed(500, "Ocorreu um erro inesperado na inclusão do lançamento.", mensagem);
            }
        }

        public async Task<Result<List<string>>> HandleAsync(List<Lancamento> lancamento)
        {
            try
            {
                foreach(var item in lancamento )
                {
                    var notificacoes = item.Validate();

                    if (notificacoes.Count > 0)
                    {
                        return Result<List<string>>.Failed(400, "O lançamento é invalido. Por favor, corrija os dados.", notificacoes);
                    }
                }

                foreach(var item in lancamento)
                {
                    var lancamentoSalvo = await _lancamentoRepository.Save(item);
                }

                return Result<List<string>>.Succeeded(200, $"Operaçaõ realizada com sucesso.");

            }
            catch(Exception ex)
            {
                var mensagem = new List<string>();
                mensagem.Add(ex.Message);
                return Result<List<string>>.Failed(500, "Ocorreu um erro inesperado na inclusão do lançamento.", mensagem);
            }
        }
    }
}