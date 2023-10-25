using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CursosOnline.Data;
using CursosOnline.Models;

namespace CursosOnline.Pages_Students
{
    public class IndexModel : PageModel
    {
        private readonly CursosOnline.Data.ApplicationDbContext _context;

        public IndexModel(CursosOnline.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Student = await _context.Students.ToListAsync();
            }
        }
    }
}
