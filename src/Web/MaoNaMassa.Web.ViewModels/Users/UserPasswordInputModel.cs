namespace MaoNaMassa.Web.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;

    public class UserPasswordInputModel
    {
        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve conter de {2} a {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve conter de {2} a {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("NewPassword", ErrorMessage = "As senhas não estão iguais.")]
        public string RepeatNewPassword { get; set; }
    }
}
