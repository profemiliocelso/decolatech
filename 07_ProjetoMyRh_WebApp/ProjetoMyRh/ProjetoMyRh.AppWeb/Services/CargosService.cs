using ProjetoMyRh.AppWeb.DAL;
using ProjetoMyRh.AppWeb.Models.Contexts;
using ProjetoMyRh.AppWeb.Models.Entities;

namespace ProjetoMyRh.AppWeb.Services
{
    public class CargosService
    {
        public GenericDao<Cargo> CargosDao { get; set; }

        public CargosService(MyRhContext context)
        {
            this.CargosDao = new GenericDao<Cargo>(context);
        }

        public void Adicionar(Cargo cargo)
        {
            CargosDao.Adicionar(cargo);
        }

        public IEnumerable<Cargo> ListarCargos(int idArea)
        {
            if(idArea > 0)
            {
                return CargosDao.Listar()
                    .Where(c => c.AreaId == idArea)
                    .ToList();
            }
            return CargosDao.Listar();
        }
    }
}
