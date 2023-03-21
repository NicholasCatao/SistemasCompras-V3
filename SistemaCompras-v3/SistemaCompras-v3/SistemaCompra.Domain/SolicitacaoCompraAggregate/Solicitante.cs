using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class Solicitante : ValueObject<Solicitante>
    {
        [Key]
        public Guid Id { get; set; }

        [Required] 
        public string Nome { get; set; }
    
        public ICollection<SolicitacaoCompra> SolicitacaoCompras { get; set; }
      
        public Solicitante()
        {
            SolicitacaoCompras = new Collection<SolicitacaoCompra>();
        }
        public Solicitante(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));
            if (nome.Length < 5) throw new BusinessRuleException("Nome de usuário deve possuir pelo menos 8 caracteres.");
            
            Nome = nome;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<object>() { Nome };
        }
    }
}
