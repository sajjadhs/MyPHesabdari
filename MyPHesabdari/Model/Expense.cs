using System;
using System.ComponentModel.DataAnnotations;

namespace MyPHesabdari.Model
{
    public class Expense
    {
        public Expense()
        {
            ExpenseDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Payer { get; set; }
        public virtual Cost Cost { get; set; }
        public int? CostId { get; set; }

        public virtual CurrencyUnit CurrencyUnit { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public int CurrencyUnitId { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}