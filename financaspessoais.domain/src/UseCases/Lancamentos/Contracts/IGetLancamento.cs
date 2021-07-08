using System.Collections.Generic;
using System.Threading.Tasks;
using FinancasPessoais.Domain.IEntities;
using FinancasPessoais.Domain.UseCases.Lancamentos.Results;

namespace FinancasPessoais.Domain.UseCases.Lancamentos.Contracts
{
    public interface IGetLancamento
    {
        Task<Result<GetLancamentosMesComTotalizacaoResult>> GetLancamentosPorMes(int ano,int mes);

    }
}