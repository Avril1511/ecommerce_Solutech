using ecommerce_Solutech.Data;
using ecommerce_Solutech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ecommerce_Solutech.Pages.CRUD{
    public class ListarModel : PageModel{

    private readonly AppDbContext _context;

		public ListarModel(AppDbContext context){
			_context = context;
		}
		public IList<Cliente> Clientes { get; set; }

		public async Task<IActionResult> OnGet(){
			Clientes = await _context.cliente.ToListAsync();

            return Page();

		}

		public async Task<IActionResult> OnPostDeleteAsync(int? id){
		//Busca no banco de dados o cliente com o mesmo id procurado
			var cliente = await _context.cliente.FirstOrDefaultAsync( c => c.Id == id);

			//Verifica se foi retornado algun cliente no banco de dados
			if (cliente != null){
				_context.cliente.Remove(cliente);
				await _context.SaveChangesAsync();

			}

			//Redireciona para a p�gina de listagem de cliente
			return RedirectToPage("./Listar");
		}
    }
}
