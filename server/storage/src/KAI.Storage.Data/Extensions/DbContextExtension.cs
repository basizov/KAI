using KAI.Storage.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KAI.Storage.Data.Extensions
{
	public static class DbContextExtension
	{
		public static IServiceCollection ConnectDbContext(
			this IServiceCollection services,
			string connectionString)
		{
			services.AddDbContext<StorageDbContext>(opt =>
			{
				opt.UseLazyLoadingProxies();
				opt.UseNpgsql(connectionString);
				opt.UseSnakeCaseNamingConvention();
			});
			return services;
		}
	}
}
