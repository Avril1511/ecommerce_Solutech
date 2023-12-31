using CodigoApoio;
using ecommerce_Solutech.Data;
using ecommerce_Solutech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ecommerce_Solutech.Pages.ProdutoCRUD {
	public class IncluirModel : PageModel
	{
		private readonly AppDbContext _context;

		[BindProperty]
		public Produto produto { get; set; }

		private readonly IWebHostEnvironment _webHostEnvironment;

		public string CaminhoImagem { get; set; }

		[BindProperty]
		[DisplayName("Imagem do Produto")]
		[Required(ErrorMessage = "O campo \"{0}\" � de preenchimento obrigatorio.")]

		public IFormFile ImagemProduto { get; set; }

		public IncluirModel(AppDbContext context, IWebHostEnvironment whe)
		{
			_context = context;
			_webHostEnvironment = whe;    
			CaminhoImagem = "/img/produto/sem_imagem.jpg";

		}

		public void OnGet() {
		}
		public async Task<IActionResult> OnPostAsync() {
			if (ImagemProduto == null){
				return Page();
			}
			var produto = new Produto();


			bool formValidado = await TryUpdateModelAsync(
												produto,
												produto.GetType(),
												nameof(Produto)
											);

			if (formValidado) { 

				_context.produtos.Add( produto );
				await _context.SaveChangesAsync();

				await AppUtils.ProcessarArquivoDeImagem(produto.Id, ImagemProduto, _webHostEnvironment);
				
				return RedirectToPage("./Listar");
			}


			return Page();
			
		}
	}
}
