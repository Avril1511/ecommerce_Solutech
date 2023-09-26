using ecommerce_Solutech.Data;
using ecommerce_Solutech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_Solutech.Pages.CRUD.ProdutoCRUD
{
    public class AlterarModel : PageModel
    {
        private readonly AppDbContext _context;

        public AlterarModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]

        public Produto produto { get; set; }

        public async Task<IActionResult> OnGet(int id) {
            produto = await _context.produtos.FirstOrDefaultAsync(c => c.Id == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            _context.Attach(produto).State = EntityState.Modified;
            await _context .SaveChangesAsync();
           
            return Page();
        }
    }
}
