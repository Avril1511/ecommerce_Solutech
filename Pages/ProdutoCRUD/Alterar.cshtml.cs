using CodigoApoio;
using ecommerce_Solutech.Data;
using ecommerce_Solutech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace ecommerce_Solutech.Pages.CRUD.ProdutoCRUD {
    public class AlterarModel : PageModel {
        private readonly AppDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]

        public Produto produto { get; set; }
        public string CaminhoImagem { get; set; }
        [BindProperty]
        [Display(Name = "Imagem do Produto")]
        public IFormFile ImagemProduto { get; set; }

        public AlterarModel(AppDbContext context, IWebHostEnvironment webHostEnvironment) {
            _context = context;
        }

        public async Task<IActionResult> OnGet(int id) {
            if (id == null) {
                return NotFound();
            }
			
			produto = await _context.produtos.FirstOrDefaultAsync(c => c.Id == id);

            if (produto == null) {
                return NotFound();

            }
            CaminhoImagem = $"~/img/produto/{produto.Id:D6}.jpg";

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }
            _context.Attach(produto).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
                //Se há uma imaem de produtosubmetida
                if (ImagemProduto != null)
                    await AppUtils.ProcessarArquivoDeImagem(
                        produto.Id,
                        ImagemProduto,
                        _webHostEnvironment
                );

            } catch (DbUpdateConcurrencyException error) {
                if (!ProdutoAindaNãoExiste(produto.Id)) {
                    return NotFound();
                } else {
                    throw;
                }

            } catch {
                return Page();
            }
            return RedirectToPage("./Listar");
        }

        private bool ProdutoAindaNãoExiste(int? id) {
            throw new NotImplementedException();
        }
    }
}