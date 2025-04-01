using Ambev.DeveloperEvaluation.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public Guid ProductId { get; set; }

        [NotMapped]
        public string ProductName { get; set; } = string.Empty;

        public int Quantity { get; private set; }

        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalPrice { get; set; }


        public Guid CartId { get; set; }
        public Cart Cart { get; set; }

        public void CalculateTotalPrice()
        {
            if (Quantity is >= 4 and < 10)
            {
                Discount = 0.10m;
            }
            else if (Quantity is >= 10 and <= 20)
            {
                Discount = 0.20m;
            }
            else if (Quantity > 20)
            {
                throw new DomainException("Não é possível vender mais de 20 itens idênticos.");
            }
            else
            {
                Discount = 0.0m;
            }

            TotalPrice = Quantity * UnitPrice * (1 - Discount);
        }
    }
}
