using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Shared
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Vender { get; set; }

        public string? Description { get; set; }

        [Required]
        [Display(Name = "Expense Type")]
        public int? ExpenseTypeId { get; set; }

        [Required]
        [Range(0, 500, ErrorMessage = "The {0} firld must be <= {2}")]
        public decimal? Amount { get; set; }

        public bool Paid { get; set; }
    }

    public class ExpenseType
    {
        public int Id { get; set; }

        public string? Type { get; set; }
    }
}
