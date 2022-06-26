using KAI.Storage.Api.Extensions;
using KAI.Storage.Data.Constants;
using KAI.Storage.Data.Extensions;

try
{
	var builder = WebApplication.CreateBuilder(args);
	var configuration = builder.Configuration;

	builder.Logging.ClearProviders();
	builder.Logging.ConnectSerilog(configuration);

	builder.Services.AddHttpContextAccessor();

	builder.Services.AddHttpClient();
	builder.Services.ConnectControllers();
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.ConnectOpenApi();

	var connectionString = configuration.GetConnectionString(ConfigContants.DB_CONTEXT_CONNECTION);
	builder.Services.ConnectDbContext(connectionString);

	var app = builder.Build();

	app.UseSwagger();
	app.UseSwaggerUI();
	app.MapControllers();
	await app.RunAsync();
}
catch (Exception ex)
{

}
finally
{

}
