using System.ComponentModel.DataAnnotations;

namespace ProjetoMyRh.API.Auth
{
    public class LoginModel
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
