using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskRazor.Data;
using MegaDeskRazor.Models;

namespace MegaDeskRazor.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskRazor.Data.MegaDeskRazorContext _context;

        public IndexModel(MegaDeskRazor.Data.MegaDeskRazorContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList CustomerNames { get; set; }
       
        public string DeskCustomerName { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            IQueryable<DeskQuote> query = from d in _context.DeskQuote
                                           select d;

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.CustomerName.Contains(searchString));

            }
            DeskQuote = await query.ToListAsync();
        }
    }
}
