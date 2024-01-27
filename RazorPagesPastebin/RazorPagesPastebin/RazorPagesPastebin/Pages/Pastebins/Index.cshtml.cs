using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesPastebin.Data;
using RazorPagesPastebin.Models;

namespace RazorPagesPastebin.Pages.Pastebins
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly RazorPagesPastebin.Data.RazorPagesPastebinContext _context;

        public IndexModel(RazorPagesPastebin.Data.RazorPagesPastebinContext context)
        {
            _context = context;
        }

        public IList<Pastebin> Pastebin { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Pastebin = await _context.Pastebin.ToListAsync();
        }
    }
}
