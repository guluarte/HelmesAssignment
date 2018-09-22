using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HelmesAssignment.DataLayer;
using HelmesAssignment.Interfaces;

namespace HelmesAssignment.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _dbContext;

        protected BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InsertAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task InsertOrModifyAsync(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            if (_dbContext.Set<TEntity>().Any(predicate))
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                _dbContext.Entry(entity).State = EntityState.Added;
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteASync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }
    }
}