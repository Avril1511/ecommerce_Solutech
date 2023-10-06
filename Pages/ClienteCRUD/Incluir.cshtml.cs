using ecommerce_Solutech.Data;
using ecommerce_Solutech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ecommerce_Solutech.Pages.CRUD
{
    public class IncluirModel : PageModel
    {
        private readonly AppDbContext _context;

		public IncluirModel (AppDbContext context){
            _context = context;
        }

        [BindProperty]
        public Cliente cliente { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync() {
            var cliente = new Cliente();
            _context.cliente.Add(cliente);

            bool validado = await TryUpdateModelAsync<Cliente>(
                                cliente,
                                "cliente",
								o => o.Nome, o => o.email, o => o.DataNascimento, o => o.telefone, o => o.Cpf
				);


            if (validado)
            {
                _context.cliente.Add(cliente);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Listar");
            } else
            {
                return Page();
            }

        }
    }
}
