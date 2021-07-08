using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using FinancasPessoais.data.Configurations;
using FinancasPessoais.Domain.Entities;
using FinancasPessoais.Domain.IRepositories;
using Dapper;
using FinancasPessoais.data.EntityData;
using System.Linq;

namespace FinancasPessoais.data.Repositories
{
    public class LancamentoSqlRepository : ILancamentoRepository
    {
        public async Task<Lancamento> Get(string id)
        {
            try
            {
                using(var connection = new SqlConnection(DataBaseConfigurationParameters.ConnectionString))
                {
                    StringBuilder sqlCommandText = new StringBuilder();
                    sqlCommandText.Append("SELECT Id,DataLancamento,valor,Conta,TipoLancamento FROM LANCAMENTOS L WHERE L.ID = @Id");

                    var result = await connection.QueryAsync<LancamentoEntityData>(sqlCommandText.ToString(), new {
                        Id = id
                    });
                    
                    return result.FirstOrDefault().ToEntityDomain();
                    
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Lancamento>> GetLancamentosPorMes(int ano, int mes)
        {
            try
            {
                using(var connection = new SqlConnection(DataBaseConfigurationParameters.ConnectionString))
                {
                    StringBuilder sqlCommandText = new StringBuilder();
                    sqlCommandText.Append("SELECT Id,DataLancamento,valor,Conta,TipoLancamento FROM LANCAMENTOS L ");
                    sqlCommandText.Append(" where Month(DataLancamento) = @Mes and Year(DataLancamento) = @Ano");


                    var result = await connection.QueryAsync<LancamentoEntityData>(sqlCommandText.ToString(), new {
                        Mes = mes,
                        Ano = ano
                    });
                    
                    var entityDomain =  result.ToList().Select(x => x.ToEntityDomain()).ToList();
                    
                    return entityDomain;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Lancamento> Save(Lancamento value)
        {
            try
            {
                using(var connection = new SqlConnection(DataBaseConfigurationParameters.ConnectionString))
                {
                    StringBuilder sqlCommandText = new StringBuilder();
                    sqlCommandText.Append("INSERT INTO LANCAMENTOS (Id, DataLancamento, Valor, TipoLancamento, Conta)");
                    sqlCommandText.Append("VALUES (@Id, @DataLancamento, @Valor, @TipoLancamento, @Conta)");
                    
                    value.Id = Guid.NewGuid().ToString();

                    var result = await connection.ExecuteAsync(sqlCommandText.ToString(),
                    new {
                        Id = Guid.Parse(value.Id),
                        DataLancamento = value.DataLancamento,
                        Valor = value.Valor,
                        TipoLancamento = value.Tipo,
                        Conta = value.Conta
                    });
                    
                    return value;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}