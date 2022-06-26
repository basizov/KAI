using KAI.Storage.Data.Entities.Abstract;
using KAI.Storage.Data.Enums;

namespace KAI.Storage.Data.Entities
{
	public class File : IEntityWithId, ISoftDeletable
	{
		public Guid Id { get; set; }

		public Guid AuthorId { get; init; }

		public string Name { get; init; } = default!;

		public FileExtension Extension { get; init; }

		public ulong Size { get; init; }

		public DateTimeOffset Created { get; init; }

		public bool IsDeleted { get; set; }
	}
}
