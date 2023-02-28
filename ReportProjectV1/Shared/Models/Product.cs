using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportProjectV1.Shared.Models
{
    public class Product : BaseEntity
    {
        /*[Key]*/
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string? ProductRef { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal? ProductPrice { get; set; }
        /* [Key]
         [ForeignKey("Category")]*/
        [Required(ErrorMessage = "The field Category is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The field Category is required")]
        public int? IDCategory { get; set; }
        public string? CategoryName { get; set; }
    }
}
