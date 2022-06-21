using KAI.Storage.Data.Entities.Abstract;
using KAI.Storage.Data.Enums;

namespace KAI.Storage.Data.Entities
{
	public class File : IEntityWithId, ISoftDeletable
	{
		public Guid Id { get; set; }

		public Guid AuthorId { get; }

		public string Name => default!;

		public FileExtension Extension { get; }

		public ulong Size { get; }

		public DateTimeOffset Created { get; }

		public bool IsDeleted { get; set; }
	}
}
