using System.ComponentModel.DataAnnotations;

namespace ProjetoMyRh.API.Models.Entities
{
    public class Candidato
    {
        [Key]
        public string? Cpf { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public ICollection<Inscricao>? Inscricoes { get; set; }
    }
}
