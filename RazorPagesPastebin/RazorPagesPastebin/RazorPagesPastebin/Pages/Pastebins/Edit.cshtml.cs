using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesPastebin.Data;
using RazorPagesPastebin.Models;

namespace RazorPagesPastebin.Pages.Pastebins
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesPastebin.Data.RazorPagesPastebinContext _context;

        public EditModel(RazorPagesPastebin.Data.RazorPagesPastebinContext context)
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

            var pastebin =  await _context.Pastebin.FirstOrDefaultAsync(m => m.Id == id);
            if (pastebin == null)
            {
                return NotFound();
            }
            Pastebin = pastebin;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pastebin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PastebinExists(Pastebin.Id))
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

        private bool PastebinExists(int id)
        {
            return _context.Pastebin.Any(e => e.Id == id);
        }
    }
}
