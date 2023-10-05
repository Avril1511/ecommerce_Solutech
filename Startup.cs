using ecommerce_Solutech.Data;
using ecommerce_Solutech.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ecommerce_Solutech {
	public class Startup {

		public Startup(IConfiguration configuration) { 
		    Configuration = configuration;
		
		}
		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {

			services.Configure<CookiePolicyOptions>(options => {
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.Lax;
			});
			services.AddIdentity<AppUser, IdentityRole>(options => {
				options.User.RequireUniqueEmail = true;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
				options.Lockout.MaxFailedAccessAttempts = 3;
				options.SignIn.RequireConfirmedAccount = false;
				options.SignIn.RequireConfirmedEmail = false;
				options.SignIn.RequireConfirmedPhoneNumber = false;
			}).AddEntityFrameworkStores<AppDbContext>();


			services.ConfigureApplicationCookie(options => {
				options.Cookie.HttpOnly = true;
				options.ExpireTimeSpan = TimeSpan.FromMinutes(3);
				options.LoginPath = "/Login";
				options.AccessDeniedPath = "/Login";
				options.SlidingExpiration = true;

			});
			services.AddAuthorization(options => {
				//add uma política de acesso com nome isAdmin
				options.AddPolicy("isAdmin", policy =>
				policy.RequireRole("admin"));
			});
					
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
			services.AddRazorPages(options => {
				options.Conventions.AuthorizePage("/ProdutoCRUD", "isAdmin");
				options.Conventions.AuthorizePage("/ClienteCRUD", "isAdmin");
			}).AddCookieTempDataProvider(opt => opt.Cookie.IsEssential = true);
			 
		}
		public void Configure(WebApplication app , IWebHostEnvironment env) {

			if (!app.Environment.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();
			var defaultCulture = new CultureInfo("pt-BR");
			var localizationOptions = new RequestLocalizationOptions {
				DefaultRequestCulture = new RequestCulture(defaultCulture),
				SupportedCultures = new List<CultureInfo> { defaultCulture },
				SupportedUICultures = new List<CultureInfo> { defaultCulture }
			};

			app.UseRequestLocalization(localizationOptions);

			app.MapRazorPages();

			app.Run();


		}







	}
}
