using System.ComponentModel.DataAnnotations;

namespace ControleLoja.WebUI.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Senha")]
        [Compare("Senha", ErrorMessage = "Senhas não encontrada")]
        public string ConfirmaSenha { get; set; }
    }
}
