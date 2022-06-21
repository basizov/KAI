namespace KAI.Storage.Api.Extensions
{
	public static class OpenApiExtension
	{
		public static IServiceCollection ConnectOpenApi(this IServiceCollection services)
		{
			return services.AddSwaggerGen();
		}
	}
}
