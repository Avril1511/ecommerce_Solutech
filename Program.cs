using ecommerce_Solutech.Data;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_Solutech {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            var _mySqlServerVersion = new MySqlServerVersion(new Version(8, 0, 33));

            builder.Services.AddDbContext<AppDbContext>(
                options => {
                    options.UseMySql(
                       builder.Configuration.GetConnectionString("DBString"),
                        _mySqlServerVersion,
                        opt => opt.EnableRetryOnFailure()
					   );

				}
             );
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

			app.Run();
		}
    }
}