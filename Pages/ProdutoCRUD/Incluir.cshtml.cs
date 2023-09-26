using ecommerce_Solutech.Data;
using ecommerce_Solutech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ecommerce_Solutech.Pages.ProdutoCRUD {
	public class IncluirModel : PageModel
    {
		private readonly AppDbContext _context;

		public IncluirModel(AppDbContext context) {
			_context = context;
		}

		[BindProperty]
		public Produto produto { get; set; }

		public void OnGet() {
		}
		public async Task<IActionResult> OnPostAsync() {
			_context.produtos.Add(produto);

			await _context.SaveChangesAsync();

			return Page();

			//return RedirectToPage("./Listar");



		}
	}
}
