using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CursosOnline.Data;
using CursosOnline.Models;

namespace CursosOnline.Pages_Subscribers
{
    public class EditModel : PageModel
    {
        private readonly CursosOnline.Data.ApplicationDbContext _context;

        public EditModel(CursosOnline.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Subscriber Subscriber { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Subscribers == null)
            {
                return NotFound();
            }

            var subscriber =  await _context.Subscribers.FirstOrDefaultAsync(m => m.Id == id);
            if (subscriber == null)
            {
                return NotFound();
            }
            Subscriber = subscriber;
           ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Email");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Subscriber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriberExists(Subscriber.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SubscriberExists(int id)
        {
          return (_context.Subscribers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
