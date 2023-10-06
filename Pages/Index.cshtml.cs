using ecommerce_Solutech.Data;
using ecommerce_Solutech.Models;
using ecommerce_Solutech.Pages.CRUD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ecommerce_Solutech.Pages{
    public class IndexModel : PageModel
    {
        
        
        
        
        private readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        public IList<Produto> Produtos { get; set; }

        private int paginaAtual = 1;

        public int QuantidadePagina { get; private set; }
        private int qtdProdutoPagina = 12;
       

        public async Task OnGet([FromQuery(Name = "q")] string TermoBusca, [FromQuery(Name = "p")] int? pagina, [FromQuery(Name = "o")] int? ordem) {

            paginaAtual = pagina ?? 1;

            var query = _context.produtos.AsQueryable();
            

            if (!string.IsNullOrEmpty(TermoBusca)) {
                query = query.Where(
                        p => p.Nome.ToLower().Contains(TermoBusca.ToLower())
                );
            }

            if (ordem.HasValue) {
                switch (ordem.Value) {
                    case 1:
                        query = query.OrderBy(p => p.Nome.ToLower());
                        break;
                    case 2:
                        query = query.OrderBy(p => p.Preco);
                        break;
                    case 3:
                        query = query.OrderByDescending(p => p.Preco);
                        break;
                }
            }

            var stage = query;
            var qtdProdutos = stage.Count();

            var resultado = Math.Ceiling(qtdProdutos * 1.0 / qtdProdutoPagina);

            QuantidadePagina = Convert.ToInt32(resultado);   //Aqui você deve escrever o calculo para obter a quantidade de páginas, você já ter definido quantos produtos deve ter em cada página, e também possui a quantidade de produto em toda o sistema. O número a obter deve ser no tipo inteiro


            query = query.Skip(qtdProdutoPagina  * (this.paginaAtual - 1)).Take(qtdProdutoPagina);



            Produtos = await query.ToListAsync(); }
        }
    }
