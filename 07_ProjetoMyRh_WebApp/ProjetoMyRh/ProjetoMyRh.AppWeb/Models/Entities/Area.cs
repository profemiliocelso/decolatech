namespace ProjetoMyRh.AppWeb.Models.Entities
{
    public class Area
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public ICollection<Cargo>? Cargos { get; set; }


    }
}
