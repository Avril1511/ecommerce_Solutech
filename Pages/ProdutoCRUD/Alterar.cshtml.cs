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
            if ( id == null) {
                return NotFound();
            }

            produto = await _context.produtos.FirstOrDefaultAsync(c => c.Id == id);

            if ( produto == null ) {
                return NotFound();

            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }
            _context.Attach(produto).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException error) {
                if (!ProdutoAindaNãoExiste(Produto.Id)) {
                    return NotFound();
                } else {
                    throw;
                }

            } catch {
                return Page();
        }
            return RedirectToPage("./Listar");
        }

