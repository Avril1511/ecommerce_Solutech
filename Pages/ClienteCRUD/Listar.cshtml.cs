using ecommerce_Solutech.Data;
using ecommerce_Solutech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_Solutech.Pages.CRUD
{
    public class ListarModel : PageModel
    {
        private readonly AppDbContext _context;

		public ListarModel(AppDbContext context) {
			_context = context;
		}
        public IList<Cliente> Clientes { get; set; }
		public async Task<IActionResult> OnGet(){
            //Busca no banco de dados o clientecom o mesmo id procurado
            Clientes = await _context.cliente.ToListAsync();

            return Page();       
        }
        public async Task<IActionResult> OnPostDeleteAsync(int? id) {

            var cliente = await _context.cliente.FirstOrDefaultAsync( c => c.Id == id );
            //Verificar se foi retornado algum cliente de banco de dados
            if (cliente != null) {
                _context.cliente.Remove(cliente);
                await _context.SaveChangesAsync();
            }
            //Redireciona para a página de listagem de Cliente
            return RedirectToPage("./Listar");
        }

    }
}
