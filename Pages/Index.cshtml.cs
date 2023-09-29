using ecommerce_Solutech.Data;
using ecommerce_Solutech.Models;
using ecommerce_Solutech.Pages.CRUD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_Solutech.Pages{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        public IList<Produto> Produtos { get; set; }


        public async Task<IActionResult> OnGet()
        {
            Produtos = await _context.produtos.ToListAsync();

            return Page();

        }
    }
}