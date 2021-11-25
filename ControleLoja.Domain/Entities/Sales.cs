using ControleLoja.Domain.Validation;
using System;

namespace ControleLoja.Domain.Entities
{
    public class Sales : Entity
    {
        
        public Guid IdProduct { get; set; }
        public Product Product { get; set; }
        public int Qtd { get; set; }
        public string NameClient { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Sales()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        public Sales(Guid idProduct, Product product, int qtd, string nameClient, DateTime createdAt, DateTime updatedAt)
        {
            ValidateDomain(idProduct, product, qtd, nameClient, createdAt, updatedAt);
        }

        private void ValidateDomain(Guid idProduct, Product product, int qtd, string nameClient, DateTime createdAt, DateTime updatedAt)
        {
            throw new Exception();
        }
    }
}
