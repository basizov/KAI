using System.Text.Json;
using System.Text.Json.Serialization;

namespace KAI.Storage.Api.Extensions
{
	public static class MvcBuilderExtension
	{
		public static IMvcBuilder ConnectJsonOptions(this IMvcBuilder builder)
		{
			return builder.AddJsonOptions(opt =>
			{
				opt.AllowInputFormatterExceptionMessages = true;
				opt.JsonSerializerOptions.IncludeFields = false;
				opt.JsonSerializerOptions.IgnoreReadOnlyFields = true;
				opt.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
				opt.JsonSerializerOptions.MaxDepth = 2;
				opt.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
				opt.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;
				opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
				opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumMemberConverter());
			});
		}
	}
}
