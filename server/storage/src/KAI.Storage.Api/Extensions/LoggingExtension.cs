using Serilog;

namespace KAI.Storage.Api.Extensions
{
	public static class LoggingExtension
	{
		public static ILoggingBuilder ConnectSerilog(
			this ILoggingBuilder builder,
			IConfiguration configuration)
		{
			var logger = new LoggerConfiguration()
				.ReadFrom.Configuration(configuration)
				.CreateLogger();

			builder.AddSerilog(logger);

			return builder;
		}
	}
}
