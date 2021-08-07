using System.Collections.Generic;
using System.Linq;
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

        public Cliente getByCPF(long cpf)
        {
            return _dbContext.Set<Cliente>().Find(cpf);
        }

        public IEnumerable<Cliente> getByName(string name)
        {
            return _dbContext.Set<Cliente>().Where(n => n.nome == name);
        }
    }
}