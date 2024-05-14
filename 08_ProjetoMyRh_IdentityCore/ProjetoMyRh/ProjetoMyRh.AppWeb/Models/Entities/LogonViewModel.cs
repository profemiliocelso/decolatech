using System.ComponentModel.DataAnnotations;

namespace ProjetoMyRh.AppWeb.Models.Entities
{
    public class LogonViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Senha { get; set; }

        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get; set; }
    }
}
