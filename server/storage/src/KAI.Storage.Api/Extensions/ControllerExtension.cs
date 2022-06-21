namespace KAI.Storage.Api.Extensions
{
	public static class ControllerExtension
	{
		public static IServiceCollection ConnectControllers(this IServiceCollection services)
		{
			services.AddControllers()
				.ConnectJsonOptions();
			return services;
		}
	}
}
