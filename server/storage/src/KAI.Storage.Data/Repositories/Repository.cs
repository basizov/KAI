using KAI.Storage.Data.Contexts;
using KAI.Storage.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KAI.Storage.Data.Repositories
{
	internal class Repository<T> : IRepository<T>
		where T : class
	{
		private readonly DbSet<T> _dbSet;
		private readonly StorageDbContext _context;

		public Repository(StorageDbContext context)
		{
			_dbSet = context.Set<T>();
			_context = context;
		}

		public virtual IQueryable<T> AsQueryable()
		{
			return _dbSet;
		}

		public virtual IQueryable<T> AsNoTracking()
		{
			return _dbSet.AsNoTracking();
		}

		public virtual async Task<T> Create(T entity)
		{
			var entityEntry = await _context.AddAsync(entity);

			var createdEntity = entityEntry.Entity;
			return createdEntity;
		}

		public virtual T Update(T entity)
		{
			var entityEntry = _dbSet.Attach(entity);

			var modifiedEntity = entityEntry.Entity;
			_context.Entry(modifiedEntity).State = EntityState.Modified;

			return modifiedEntity;
		}

		public virtual void Delete(T entity)
		{
			if (_context.Entry(entity).State == EntityState.Detached)
			{
				_dbSet.Attach(entity);
			}

			_dbSet.Remove(entity);
		}

		public virtual Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
		{
			return _dbSet.AnyAsync(expression);
		}
	}
}
