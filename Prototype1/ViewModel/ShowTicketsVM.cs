using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prototype1.Models;

namespace Prototype1.ViewModel
{
    public class ShowTicketsVM
    {
        public ShowTIcketsClass ? tIcketsClass { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? obj { get; set; }

    }
}
