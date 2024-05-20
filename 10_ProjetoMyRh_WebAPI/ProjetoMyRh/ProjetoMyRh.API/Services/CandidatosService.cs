using ProjetoMyRh.API.DAL;
using ProjetoMyRh.API.Models.Contexts;
using ProjetoMyRh.API.Models.Entities;

namespace ProjetoMyRh.API.Services
{
    public class CandidatosService
    {
        public GenericDao<Candidato, string> CandidatosDao { get; set; }
        public CandidatosService(MyRhContext context) 
        {
            this.CandidatosDao = new GenericDao<Candidato, string>(context);
        }

        public void Incluir(Candidato candidato)
        {
            CandidatosDao.Adicionar(candidato);
        }

        public Candidato? Buscar(string cpf)
        {
            return CandidatosDao.Buscar(cpf);
        }
    }
}
