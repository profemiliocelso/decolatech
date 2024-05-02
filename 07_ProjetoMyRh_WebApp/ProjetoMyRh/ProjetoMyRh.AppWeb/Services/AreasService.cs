using ProjetoMyRh.AppWeb.DAL;
using ProjetoMyRh.AppWeb.Models.Contexts;
using ProjetoMyRh.AppWeb.Models.Entities;

namespace ProjetoMyRh.AppWeb.Services
{
    public class AreasService
    {
        public GenericDao<Area> AreasDao { get; set; }

        public AreasService(MyRhContext context)
        {
            this.AreasDao = new GenericDao<Area>(context);
        }

        public IEnumerable<Area> Listar()
        {
            return AreasDao.Listar();
        }
    }
}
