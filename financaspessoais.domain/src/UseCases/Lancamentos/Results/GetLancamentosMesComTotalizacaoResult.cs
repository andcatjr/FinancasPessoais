using System.Collections.Generic;
using FinancasPessoais.Domain.Entities;
using FinancasPessoais.Domain.IEntities;

namespace FinancasPessoais.Domain.UseCases.Lancamentos.Results
{
    public class GetLancamentosMesComTotalizacaoResult
    {
        public Dictionary<string,decimal> Totalizadores { get; set; }
        public List<Lancamento> Lancamentos { get; set; }

        public GetLancamentosMesComTotalizacaoResult()
        {
            Totalizadores = new Dictionary<string, decimal>();
        }
    }
}