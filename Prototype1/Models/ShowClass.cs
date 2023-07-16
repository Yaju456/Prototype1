using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Prototype1.Models
{
    public class ShowClass
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        
        [DataType(DataType.Date)]
        [Required]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string? Description { get; set; }

        [ValidateNever]
        public string ? imgurl { get; set; }
    }
}
