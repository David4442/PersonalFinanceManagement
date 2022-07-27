using PersonalFinanceManagement.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceManagement.Database.Entities
{
    public class SubCategoryEntity
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string ParentCode { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("ParentCode")]
        public virtual Category category { get; set; }
    }
}
