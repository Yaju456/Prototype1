using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prototype1.Models
{
    public class ShowDateClass
    {
        [Key]
        public int TicketId { get; set; }

        [Required]
        public int ShowTicketID{ get; set;}
        [ForeignKey("ShowTicketID")]
        [ValidateNever]
        public ShowTIcketsClass? showTIcketsClass { get; set; }
        public string ? Qrvalue { get; set; }

        public int Checked { get; set; }

        public string? PaymentMethod { get; set; }

    }
}
