using PC.MyAirport.EF;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirport.Razor.Pages.Bagages
{
    public class BagageModel : PageModel
    {


        protected SelectList SelectListVols
        {
            get
            {
                var vols = _context.Vols.Select(v => new { v.VolId, Description = $"{v.Cie} {v.Lig} : {v.Dhc.ToShortDateString()}" }).ToList();
                

                return new SelectList(vols, "VolId", "Description");
            }
        }

        protected readonly MyAirportContext _context;
        public BagageModel(MyAirportContext context)
        {
            _context = context;
        }



    }
}
