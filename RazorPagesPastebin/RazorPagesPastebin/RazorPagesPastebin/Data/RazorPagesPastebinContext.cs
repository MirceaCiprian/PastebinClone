using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesPastebin.Models;

namespace RazorPagesPastebin.Data
{
    public class RazorPagesPastebinContext : DbContext
    {
        public RazorPagesPastebinContext (DbContextOptions<RazorPagesPastebinContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesPastebin.Models.Pastebin> Pastebin { get; set; } = default!;
        public DbSet<RazorPagesPastebin.Models.User> User { get; set; } = default!;
    }
}
