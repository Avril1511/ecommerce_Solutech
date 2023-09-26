
using ecommerce_Solutech.Data;
using ecommerce_Solutech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_Solutech.Pages.ProdutoCRUD
{
	public class ListarProduto : PageModel
	{
		private readonly AppDbContext _context;
		

		public ListarProduto(AppDbContext context)
		{
			_context = context;
		}
		public IList<Produto> Produtos { get; set; }

		public async Task<IActionResult> OnGet()
		{
			//Busca no banco de dados o produto com o mesmo id procurado
			Produtos = await _context.produtos.ToListAsync();

			return Page();
		}
		public async Task<IActionResult> OnPostDeleteAsync(int? id)
		{

			var produto = await _context.produtos.FirstOrDefaultAsync(c => c.Id == id);
			//Verificar se foi retornado algum produto de banco de dados
			if (produto != null)
			{
				_context.produtos.Remove((Produto)produto);
				await _context.SaveChangesAsync();
			}
			//Redireciona para a página de listagem de produto
			return RedirectToPage("./Listar");
		}

	}
}
