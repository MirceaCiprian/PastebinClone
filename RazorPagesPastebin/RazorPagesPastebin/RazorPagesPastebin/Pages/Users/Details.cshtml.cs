using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesPastebin.Data;
using RazorPagesPastebin.Models;

namespace RazorPagesPastebin.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesPastebin.Data.RazorPagesPastebinContext _context;

        public DetailsModel(RazorPagesPastebin.Data.RazorPagesPastebinContext context)
        {
            _context = context;
        }

        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                User = user;
            }
            return Page();
        }
    }
}
