using System.Linq.Expressions;

namespace KAI.Storage.Data.Repositories.Abstract
{
	internal interface IRepository<T>
		where T : class
	{
		IQueryable<T> AsQueryable();

		IQueryable<T> AsNoTracking();

		Task<T> Create(T entity);

		T Update(T entity);

		void Delete(T entity);

		Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
	}
}
