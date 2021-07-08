using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FinancasPessoais.Domain.IEntities;

namespace FinancasPessoais.Domain.Entities
{
    public class Lancamento : ILancamento
    {
        public string Id { get; set; }
        public DateTime DataLancamento { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public string Conta { get; set; }
        [MaxLength(1,ErrorMessage ="O valor deve ser apenas de 1 caracter e deve ser D ou C")]
        public string Tipo { get; set; }

        public string GetId()
        {
            return Id;
        }

        public List<string> Validate()
        {
            List<string> notifications = new List<string>();
            
            if(Valor <= 0)
                notifications.Add("Valor precisa ser superior a 0.");
            if(String.IsNullOrEmpty(Descricao))
                notifications.Add("Descrição de lançamento não pode estar vazia.");
            if(String.IsNullOrEmpty(Conta))
                notifications.Add("Conta não pode estar vazia.");
            if(Tipo == null || !(new String[]{"D","C"}.Contains(Tipo.ToUpper())) )
                notifications.Add("Tipo de lançamento não pode ser vazio e/ou deve ser apenas classificado como D (Débito) ou C (Crédito)");

            return notifications;
        }
        
    }
}