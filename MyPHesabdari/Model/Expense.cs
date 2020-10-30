using System;

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
        public int? CurrencyUnitId { get; set; }

        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}