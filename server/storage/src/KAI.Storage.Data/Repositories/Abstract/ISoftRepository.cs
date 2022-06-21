using KAI.Storage.Data.Entities.Abstract;

namespace KAI.Storage.Data.Repositories.Abstract
{
	internal interface ISoftRepository<T> : IRepository<T>
		where T : class, ISoftDeletable
	{
	}
}
