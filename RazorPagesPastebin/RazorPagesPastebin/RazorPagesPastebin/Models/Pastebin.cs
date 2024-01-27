using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesPastebin.Models
{
    public class Pastebin
    {
        public int Id { get; set; }
        [Display(Name = "New Paste")]
        public string? Paste { get; set; }
        public string? Category { get; set; }
        public string? Tags { get; set; }
        public string? SyntaxHighlighting { get; set; }
        public string? PasteExpiration { get; set; }
        public string? PasteExposure { get; set; }
        public string? Folder { get; set; }
        public string? Password { get; set; }
        public string? Title { get; set; }
    }
}
