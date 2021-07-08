using System;
using FinancasPessoais.Domain.Entities;

namespace FinancasPessoais.data.EntityData
{
    public class LancamentoEntityData
    {
        public Guid Id { get; set; }
        public DateTime DataLancamento { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public string Conta { get; set; }
        public string TipoLancamento { get; set; }

        public Lancamento ToEntityDomain()
        {
            return new Lancamento
            {
                Id = this.Id.ToString(),
                Conta = this.Conta,
                DataLancamento = this.DataLancamento,
                Descricao = this.Descricao,
                Tipo = this.TipoLancamento,
                Valor = this.Valor
            };
        }
    }
}