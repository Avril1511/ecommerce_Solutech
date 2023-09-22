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


		public async Task<IActionResult> OnGet(int id){ 
			cliente = await _context.cliente.FirstOrDefaultAsync(c => c.Id == id);

			return Page();
        }
		public async Task<IActionResult> OnPostAsync() {
			 _context.Attach(cliente).State = EntityState.Modified; 
			 await _context.SaveChangesAsync();

			return Page();
		}
    }
}
