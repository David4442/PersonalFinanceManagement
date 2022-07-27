using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceManagement.Database.Entities
{
    public class CategoryEntity
    {
        [Required]
        [Key]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string ParentCode { get; set; }
    }
}
