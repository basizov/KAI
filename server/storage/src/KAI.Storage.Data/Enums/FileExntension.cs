using System.Text.Json.Serialization;

namespace KAI.Storage.Data.Enums
{
	public enum FileExtension
	{
		[JsonPropertyName("DOC")] Doc = 1,
		[JsonPropertyName("PDF")] Pdf= 2,
		[JsonPropertyName("PNG")] Png= 3,
		[JsonPropertyName("JPG")] Jpg= 4,
		[JsonPropertyName("XLSX")] Xlsx = 5
	}
}
