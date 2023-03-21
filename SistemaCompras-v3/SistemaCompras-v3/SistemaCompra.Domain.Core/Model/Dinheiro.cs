using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaCompra.Domain.Core.Model
{
    public class Dinheiro : ValueObject<Dinheiro>
    {
        [Key]
        public Guid Id { get; set; }
        public  decimal Valor { get; set; }

        public string Moeda { get; set; } = "BRL";

        public Dinheiro()
                : this(0m)
        {
        }

        public Dinheiro(decimal value)
        {
            Valor = value;
        }

        public Dinheiro Add(Dinheiro money)
        {
            return new Dinheiro(Valor + money.Valor);
        }

        public Dinheiro Subtract(Dinheiro money)
        {
            return new Dinheiro(Valor - money.Valor);
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<Object>() { Valor };
        }
    }
}
