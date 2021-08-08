using System.Linq;
using oferta_domain.Entities;
using oferta_domain.Interfaces.Repositories;

namespace oferta_infra.Repositories
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        private readonly DataBaseContext _dbContext;
        public RepositoryUsuario(DataBaseContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
        public Usuario BuscarUsuarioPorEmail(string email)
        {
            return _dbContext.Set<Usuario>().FirstOrDefault(u => u.email == email);
        }
    }
}