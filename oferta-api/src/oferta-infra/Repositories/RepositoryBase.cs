using System.Collections.Generic;
using System.Linq;
using oferta_domain.Interfaces.Repositories;

namespace oferta_infra.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DataBaseContext _dbContext;

        public RepositoryBase(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public void Add(TEntity obj)
        {
            _dbContext.Set<TEntity>().Add(obj);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _dbContext.Set<TEntity>().Update(obj);
            _dbContext.SaveChanges();
        }
        
        public void Remove(TEntity obj)
        {
            _dbContext.Set<TEntity>().Remove(obj);
            _dbContext.SaveChanges();
        }

    }
}