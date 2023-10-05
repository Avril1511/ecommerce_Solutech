using ecommerce_Solutech.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ecommerce_Solutech.Pages {
    public class DadosLogin {
        [Required(ErrorMessage = "O campo \"{0}\" deve ser preenchido.")]
        [EmailAddress(ErrorMessage = "Você deve digitar no fromato de um email.")]
        [Display(Name = "E-mails")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [Required(ErrorMessage = "O campo \"{0}\" deve ser preenchido.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]

        public string Senha { get; set; }

        [Display(Name = "Lembrar de mim")]

        public bool Lembrar { get; set; }
    }
    public class LoginModel : PageModel {
        [BindProperty]
        public DadosLogin Dados { get; set; }

        public string ReturnURL { get; set; }

        [TempData]
        public string MensagemError { get; set; }

        private readonly SignInManager<AppUser> _signInManager;

        public LoginModel(SignInManager<AppUser> singInManager) {
            _signInManager = singInManager;
        }
        public async Task OnGetAsync(string returnURL = null) {
            if (!string.IsNullOrEmpty(MensagemError)) {
                ModelState.AddModelError(string.Empty, MensagemError);
            }
            returnURL = ReturnURL ?? Url.Content("~/");

            await HttpContext.SignOutAsync(
                                IdentityConstants.ExternalScheme
                       );

            ReturnURL = returnURL;

        }
        public async Task<IActionResult> OnPostAsync(string returnURL = null) {
            returnURL = returnURL ?? Url.Content("~/");

            if (ModelState.IsValid) {
                var result = await _signInManager.PasswordSignInAsync(
                                                    Dados.Email,
                                                    Dados.Senha,
                                                    Dados.Lembrar,
                                                    lockoutOnFailure: false
                                                    );
                if (result.Succeeded) {
                    return LocalRedirect(returnURL);
                } else {
                    ModelState.AddModelError(
                        string.Empty,
                        "Tentativa de Login inválida."
                    );
                    return Page();
                }

            }

            return Page();
        }
        public async Task<IActionResult> OnPostLogouAsync(string returnURL = null) {
            await _signInManager.SignOutAsync();

            if (returnURL != null) {
                return LocalRedirect(returnURL);
            } else {
                return RedirectToPage();
            }
        }
    }
}
    