using ecommerce_Solutech.Data;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_Solutech {
	public class Startup {

		public Startup(IConfiguration configuration) { 
		    Configuration = configuration;
		
		}
		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {

			var _mySqlServerVersion = new MySqlServerVersion(new Version(8, 0, 33));

			services.AddDbContext<AppDbContext>(
				options => {
					options.UseMySql(
					   Configuration.GetConnectionString("DBString"),
						_mySqlServerVersion,
						opt => opt.EnableRetryOnFailure()
					   );
				}
			 );
			services.AddRazorPages();
			 
		}
		public void Configure(WebApplication app , IWebHostEnvironment env) {

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
