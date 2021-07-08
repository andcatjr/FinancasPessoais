using System.Collections.Generic;
using System.Threading.Tasks;
using FinancasPessoais.common.interfaces;
using FinancasPessoais.Domain.Entities;

namespace FinancasPessoais.Domain.IRepositories
{
    public interface ILancamentoRepository : IRepository<Lancamento>
    {
        Task<IEnumerable<Lancamento>> GetLancamentosPorMes(int ano, int mes);

    }
}