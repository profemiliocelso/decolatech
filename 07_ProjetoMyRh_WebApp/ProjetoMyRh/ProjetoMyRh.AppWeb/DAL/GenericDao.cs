using ProjetoMyRh.AppWeb.Models.Contexts;

namespace ProjetoMyRh.AppWeb.DAL
{
    public class GenericDao<T> where T : class
    {
        private MyRhContext Context { get; set; }

        public GenericDao(MyRhContext context)
        {
            this.Context = context;
        }
        // Adicionar entidades
        public void Adicionar(T item)
        {
            Context.Add<T>(item);
            Context.SaveChanges();
        }
        // Listando todas as entidades
        public IEnumerable<T> Listar()
        {
            return Context.Set<T>().ToList();
        }
    }
}
