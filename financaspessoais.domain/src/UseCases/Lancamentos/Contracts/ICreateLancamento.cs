using System.Collections.Generic;
using System.Threading.Tasks;
using FinancasPessoais.Domain.Entities;
using FinancasPessoais.Domain.UseCases.Lancamentos.Results;

namespace FinancasPessoais.Domain.UseCases.Lancamentos.Contracts
{
    public interface ICreateLancamento
    {
        Task<Result<List<string>>> HandleAsync(Lancamento lancamento);
        Task<Result<List<string>>> HandleAsync(List<Lancamento> lancamento);
    }
}