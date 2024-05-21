using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoMyRh.API.Models.Entities
{
    public class Candidato
    {
        [Key]
        public string? Cpf { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        // O atributo JsonIgnore deve ser usado com cautela, uma vez que a
        // propriedade será ignorada em TODAS as ocorrências desta entidade
        [JsonIgnore]
        public ICollection<Inscricao>? Inscricoes { get; set; }
    }
}
