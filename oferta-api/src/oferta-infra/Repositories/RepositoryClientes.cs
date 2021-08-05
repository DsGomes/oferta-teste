using oferta_domain;
using oferta_domain.Interfaces;

namespace oferta_infra.Repositories
{
    public class RepositoryClientes : RepositoryBase<Cliente>, IRepositoryClientes
    {
        private readonly DataBaseContext _dbContext;
        public RepositoryClientes(DataBaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Cliente getByCPF(byte[] cpf)
        {
            return _dbContext.Set<Cliente>().Find(cpf);
        }

        public Cliente getByName(string name)
        {
            return _dbContext.Set<Cliente>().Find(name);
        }
    }
}