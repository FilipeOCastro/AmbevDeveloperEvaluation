using Ambev.DeveloperEvaluation.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public string Number { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; }

        public Guid UserId { get; set; }

        [NotMapped]
        public string UserName { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public string BranchName { get; set; } = string.Empty;

        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public bool IsCancelled { get; set; }

        public void AddItem(CartItem item)
        {
            item.CalculateTotalPrice();
            Items.Add(item);
            CalculateTotalAmount();
        }

        public void Cancel()
        {
            IsCancelled = true;
        }

        private void CalculateTotalAmount()
        {
            TotalAmount = 0;
            foreach (var item in Items)
            {
                TotalAmount += item.TotalPrice;
            }
        }
    }
}
