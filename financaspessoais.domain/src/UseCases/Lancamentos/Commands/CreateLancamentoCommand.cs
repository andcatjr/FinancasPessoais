using System;
using FinancasPessoais.Domain.Entities;

namespace FinancasPessoais.Domain.UseCases.Lancamentos.Commands
{
    public class CreateLancamentoCommand
    {
        public DateTime DataLancamento { get; set; }
        public string Conta { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }

        public Lancamento ToEntityDomain()
        {
            return new Lancamento()
            {
                DataLancamento = this.DataLancamento,
                Conta = this.Conta,
                Descricao = this.Conta, 
                Tipo = this.Tipo,
                Valor = this.Valor       
            };
        }
    }
}