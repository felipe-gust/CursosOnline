using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CursosOnline.Data;
using CursosOnline.Models;

namespace CursosOnline.Pages_Subscribers
{
    public class DeleteModel : PageModel
    {
        private readonly CursosOnline.Data.ApplicationDbContext _context;

        public DeleteModel(CursosOnline.Data.ApplicationDbContext context)
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

            var subscriber = await _context.Subscribers.FirstOrDefaultAsync(m => m.Id == id);

            if (subscriber == null)
            {
                return NotFound();
            }
            else 
            {
                Subscriber = subscriber;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Subscribers == null)
            {
                return NotFound();
            }
            var subscriber = await _context.Subscribers.FindAsync(id);

            if (subscriber != null)
            {
                Subscriber = subscriber;
                _context.Subscribers.Remove(Subscriber);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
