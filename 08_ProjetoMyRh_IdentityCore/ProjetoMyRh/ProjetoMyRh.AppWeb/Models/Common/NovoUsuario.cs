using Microsoft.AspNetCore.Identity;

namespace ProjetoMyRh.AppWeb.Models.Common
{
    public class NovoUsuario
    {
        public bool Success { get; set; }
        public IEnumerable<IdentityError>? Errors { get; set; }
    }
}
