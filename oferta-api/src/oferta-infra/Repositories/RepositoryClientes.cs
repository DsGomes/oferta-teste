using System.Collections.Generic;
using System.Linq;
using oferta_domain.Entities;
using oferta_domain.Interfaces.Repositories;

namespace oferta_infra.Repositories
{
    public class RepositoryClientes : RepositoryBase<Cliente>, IRepositoryClientes
    {
        private readonly DataBaseContext _dbContext;
        public RepositoryClientes(DataBaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Cliente> getByCPF(string cpf)
        {
            return _dbContext.Set<Cliente>().Where(c=> c.cpf == cpf);
        }

        public IEnumerable<Cliente> getByName(string name)
        {
            return _dbContext.Set<Cliente>().Where(n => n.nome == name);
        }
    }
}