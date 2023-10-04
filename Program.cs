using ecommerce_Solutech.Data;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_Solutech {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            var startup = new Startup(builder.Configuration);
            startup.ConfigureServices(builder.Services);

            var app = builder.Build();

            startup.Configure(app, builder.Environment);




            // Configure the HTTP request pipeline.
          
		}
    }
}