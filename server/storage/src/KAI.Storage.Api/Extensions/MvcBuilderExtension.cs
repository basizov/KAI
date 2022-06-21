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
				opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumMemberConverter());
			});
		}
	}
}
