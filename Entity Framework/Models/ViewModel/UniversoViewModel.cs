using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Entity_Framework.Models.ViewModel
{
    public class UniversoViewModel
    {
        public IEnumerable<SelectListItem> Universos { get; set; }
    }
}