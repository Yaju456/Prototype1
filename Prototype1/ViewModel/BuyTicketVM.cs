using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Prototype1.ViewModel
{
	public class BuyTicketVM
	{
		[Required]
		public string? showId { get; set; }

		[Range(1, 10)]
		public int? buyTickets { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem>? obj { get; set; }


	}

}
