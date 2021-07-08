using System.Threading.Tasks;

namespace FinancasPessoais.common.interfaces
{
    public interface IRepository<T>  where T : class
    {
        Task<T> Save(T value);
        Task<T> Get(string id);
    }   
}