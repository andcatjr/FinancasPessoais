using System.Linq;
using System.Threading.Tasks;
using FinancasPessoais.Domain.IRepositories;
using FinancasPessoais.Domain.UseCases.Lancamentos.Contracts;
using FinancasPessoais.Domain.UseCases.Lancamentos.Results;

namespace FinancasPessoais.Domain.UseCases.Lancamentos
{
    public class GetLancamento : IGetLancamento
    {
        private readonly ILancamentoRepository _lancamentoRepository;
        public GetLancamento(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }

        public async Task<Result<GetLancamentosMesComTotalizacaoResult>> GetLancamentosPorMes(int ano,int mes)
        {
            if(mes < 0 || mes > 12)
            {
                Result<GetLancamentosMesComTotalizacaoResult>.Failed(400,"O valor do mês deve ser o número do mês de 1 a 12.",null);
            }

            var lancamentos = await _lancamentoRepository.GetLancamentosPorMes(ano,mes);

            GetLancamentosMesComTotalizacaoResult resultado = new GetLancamentosMesComTotalizacaoResult();
            resultado.Lancamentos = lancamentos.ToList();

            if(resultado.Lancamentos.Count > 0)
            {
                var totalizadores = resultado.Lancamentos.GroupBy(x => x.Conta).Select(k => new {k.Key, Valor = (k.Where(w => w.Tipo == "C").Sum(v => v.Valor) - k.Where(w => w.Tipo == "D").Sum(v => v.Valor)), Tipo = k.Select(x => x.Tipo)}).ToList();
                foreach(var total in totalizadores)
                {
                    resultado.Totalizadores.Add(total.Key,total.Valor);
                }
            }

            return Result<GetLancamentosMesComTotalizacaoResult>.Succeeded(200,"",resultado);

        }
    }
}