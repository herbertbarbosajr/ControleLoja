using System.ComponentModel.DataAnnotations;

namespace ControleLoja.WebUI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid format email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Inserir sua Senha ")]
        [StringLength(20, ErrorMessage = "A {0} deve ter no minimo {2} e no maximo " +
            "{1} caracteres.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public string ReturnUrl { get; set; }
    }
}
