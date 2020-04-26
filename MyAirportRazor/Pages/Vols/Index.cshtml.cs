using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PC.MyAirport.EF;
using MyAirport.EF;

namespace MyAirport.Razor
{
    public class IndexModelVol : PageModel
    {
        private readonly PC.MyAirport.EF.MyAirportContext _context;

        public IndexModelVol(PC.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }

        public IList<Vol> Vol { get;set; }

        public async Task OnGetAsync()
        {
            Vol = await _context.Vols.ToListAsync();
        }
    }
}
