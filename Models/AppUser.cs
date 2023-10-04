using Microsoft.AspNetCore.Identity;

namespace ecommerce_Solutech.Models {
	public class AppUser : IdentityUser {

		public string Nome { get; set; }
	}
}
