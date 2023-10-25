using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CursosOnline.Data;
using CursosOnline.Models;

namespace CursosOnline.Pages_Subscribers
{
    public class CreateModel : PageModel
    {
        private readonly CursosOnline.Data.ApplicationDbContext _context;

        public CreateModel(CursosOnline.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Subscriber Subscriber { get; set; } = default!;
        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Subscribers == null || Subscriber == null)
            {
                return Page();
            }

            _context.Subscribers.Add(Subscriber);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
