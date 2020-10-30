using System.ComponentModel.DataAnnotations.Schema;

namespace MyPHesabdari.Model
{
    public class Cost
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CostId { get; set; }
        [ForeignKey("CostId")]
        public Cost ParentCost { get; set; }
    }
}