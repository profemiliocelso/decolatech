using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMyRh.AppWeb.Models.Entities
{
    public class Area
    {
        public int Id { get; set; }

        [DisplayName("Descrição")]
        [Required(
            ErrorMessage = "A descrição da área é obrigatória",
            AllowEmptyStrings = false)]
        public string? Descricao { get; set; }
        public ICollection<Cargo>? Cargos { get; set; }


    }
}
