using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesPastebin.Data;
using RazorPagesPastebin.Models;

namespace RazorPagesPastebin.Pages.Pastebins
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesPastebin.Data.RazorPagesPastebinContext _context;

        public DeleteModel(RazorPagesPastebin.Data.RazorPagesPastebinContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pastebin Pastebin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pastebin = await _context.Pastebin.FirstOrDefaultAsync(m => m.Id == id);

            if (pastebin == null)
            {
                return NotFound();
            }
            else
            {
                Pastebin = pastebin;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pastebin = await _context.Pastebin.FindAsync(id);
            if (pastebin != null)
            {
                Pastebin = pastebin;
                _context.Pastebin.Remove(Pastebin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
