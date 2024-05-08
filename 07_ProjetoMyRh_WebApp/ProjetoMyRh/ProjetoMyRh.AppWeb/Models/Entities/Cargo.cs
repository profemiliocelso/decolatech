using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMyRh.AppWeb.Models.Entities
{
    public class Cargo
    {
        public int Id { get; set; }
        
        [DisplayName("Área de Atuação")]        
        public int AreaId { get; set; }

        [DisplayName("Descrição")]
        [StringLength(100, MinimumLength = 5)]
        public string? Descricao { get; set; }

        [DisplayName("Salário")]
        public double Salario { get; set; }

        [DisplayName("Tipo de Salário")]
        [Range(1, 2, ErrorMessage = "O tipo de Salário deve ser MENSAL ou POR HORA")]
        public System.Int16 TipoSalario { get; set; }
        public Area? AreaAtuacao { get; set; }

    }
}
