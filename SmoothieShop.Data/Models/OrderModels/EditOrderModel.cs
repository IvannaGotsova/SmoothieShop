using SmoothieShop.Data.Data.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothieShop.Data.Models.OrderModels
{
    /// <summary>
    /// Holds EditOrderModel class.
    /// </summary>
    public class EditOrderModel
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        [Range(typeof(decimal), "0.00", "10000.00", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }
        public IEnumerable<Smoothie> Smoothies { get; set; } = new List<Smoothie>();
        public IEnumerable<Menu> Menus { get; set; } = new List<Menu>();
        public List<int>? MenusIds { get; set; } = new List<int>();
        public List<int>? SmoothiesIds { get; set; } = new List<int>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ((MenusIds == null || !MenusIds.Any()) &&
            (SmoothiesIds == null || !SmoothiesIds.Any()))
            {
                yield return new ValidationResult(
                    "You must select at least one menu or one smoothie.",
                    new[] { nameof(MenusIds), nameof(SmoothiesIds) });
            }
        }

        public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();
        public IEnumerable<int> SelectedMenusIds { get; set; } = new List<int>();
        public IEnumerable<OrderSmoothie> OrderssSmoothies { get; set; } = new List<OrderSmoothie> { };
        public IEnumerable<int> SelectedSmoothiesIds { get; set; } = new List<int>();
        public IEnumerable<MenuOrder> MenusOrders { get; set; } = new List<MenuOrder> { };
        public List<int>? CustomersIds { get; set; } = new List<int>();

    }
}
