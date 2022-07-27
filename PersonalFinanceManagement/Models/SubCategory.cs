using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceManagement.Models
{
    public class SubCategory
    {
        [Required]
        [Key]
        public string Code{ get; set; }
        [Required]
        public string ParentCode { get; set; }
        [Required]
        public string Name { get; set; }
       

       
    }
}
