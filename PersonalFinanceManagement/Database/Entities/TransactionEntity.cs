using PersonalFinanceManagement.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceManagement.Database.Entities
{
    public class TransactionEntity
    {
        [Required]
        public string Id { get; set; }

        public string Beneficiaryname { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public DirectionsEnum? Direction { get; set; }
        [Required]
        public double? Amount { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Currency { get; set; }

        public MccCodeEnum? Mcc { get; set; }
        [Required]
        public TransactionKindsEnum? Kind { get; set; }
       // public string Catcode { get; set; }

        [ForeignKey("Catcode")]
        public virtual Category category { get; set; }


    }
}
