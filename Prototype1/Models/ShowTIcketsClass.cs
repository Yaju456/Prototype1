using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prototype1.Models
{
    public class ShowTIcketsClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ShowDate { get; set; }

        [Required]
        public int TotalTickets { get; set; }

        [Required]
        public int soldTickets { get; set; }

        [Required]
        public string? Time { get; set; }

        public int ShowID { get; set; }

        [ForeignKey("ShowID")]
        [ValidateNever]
        public ShowClass ? Show { get; set; }
    }
}
