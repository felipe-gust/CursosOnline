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
    public class IndexModel : PageModel
    {
        private readonly CursosOnline.Data.ApplicationDbContext _context;

        public IndexModel(CursosOnline.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Subscriber> Subscriber { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Subscribers != null)
            {
                Subscriber = await _context.Subscribers.ToListAsync();
            }
        }
    }
}
