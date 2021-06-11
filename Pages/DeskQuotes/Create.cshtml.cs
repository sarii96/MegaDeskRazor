using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskRazor.Data;
using MegaDeskRazor.Models;

namespace MegaDeskRazor.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskRazor.Data.MegaDeskRazorContext _context;

        public CreateModel(MegaDeskRazor.Data.MegaDeskRazorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DeliveryId"] = new SelectList(_context.Set<Delivery>(), "DeliveryId", "DeliveryType");
            ViewData["DesktopMaterialId"] = new SelectList(_context.Set<DesktopMaterial>(), "DesktopMaterialId", "DesktopMaterialName");
            return Page();
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        [BindProperty]
        public Desk Desk { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //add Desk to database
           _context.Desk.Add(Desk);
           await _context.SaveChangesAsync();

            //add DeskQuote dynamic properties
            DeskQuote.QuoteDate = DateTime.Now;
            DeskQuote.DeskId = Desk.DeskId;
            DeskQuote.Desk = Desk;
            DeskQuote.QuotePrice = DeskQuote.GetQuotePrice(_context);

          

            _context.DeskQuote.Add(DeskQuote);
           await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
