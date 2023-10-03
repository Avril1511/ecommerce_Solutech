
using ecommerce_Solutech.Data;
using ecommerce_Solutech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_Solutech.Pages.CRUD
{
    public class AlterarModel : PageModel{
        private readonly AppDbContext _context;

		public AlterarModel(AppDbContext context){
			_context = context;
		}
		/*
		o BindProperty configura a aplicação para relacionar o atributo
		 cliente aos dados que estão vindo do Front-end
		*/
		[BindProperty]
        public Cliente cliente { get; set; }


		public async Task<IActionResult> OnGet(int? id){ 
			if(id == null) {

				return NotFound();
			}
			cliente = await _context.cliente.FirstOrDefaultAsync(c => c.Id == id);

			if (id == null) {

				return NotFound();
			}

			return Page();
        }
		public async Task<IActionResult> OnPostAsync() {
			if (!ModelState.IsValid) {

				return Page();
			}

			 _context.Attach(cliente).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			} catch (DbUpdateConcurrencyException error) {
				if (!ClienteAindaExiste(cliente.Id)) {

					return NotFound();

				} else {
					throw;
				}

			} catch {
				return Page();
			}

			return RedirectToPage("./Listar");
		}

		private bool ClienteAindaExiste(int? id) {
			return _context.cliente.Any( c => c.Id == id);
			
		}
	}
}
