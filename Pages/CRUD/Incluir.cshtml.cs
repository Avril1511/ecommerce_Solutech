using ecommerce_Solutech.Data;
using ecommerce_Solutech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ecommerce_Solutech.Pages.CRUD
{
    public class IncluirModel : PageModel
    {
        private readonly AppDbContext _context;

		public IncluirModel (AppDbContext context) {
            _context = context;
        }

        [BindProperty]
        public Cliente cliente { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync() {
            _context.cliente.Add(cliente);

            await _context.SaveChangesAsync();

            return Page();



        }
    }
}
