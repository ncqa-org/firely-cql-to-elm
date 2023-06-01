using Hl7.Cql.Poco.Fhir.Serialization;
using System.Text.Json;
using Hl7.Cql.Poco.Fhir.R4.Model;


namespace Hl7.Cql.Poco.Fhir.R4.Serialization
{
	public class MarkdownElementConverter : ElementConverter<MarkdownElement>
	{
		public MarkdownElementConverter(): base(new[] { JsonTokenType.String }, typeof(string)) { }
		protected override void Assign(MarkdownElement element, string value) => element.value = value;
		protected override void Assign(MarkdownElement element, decimal? value) => throw new JsonException();
		protected override void Assign(MarkdownElement element, bool? value) => throw new JsonException();
		public override void Write(Utf8JsonWriter writer, MarkdownElement value, JsonSerializerOptions options)
		{
			if (value.value != null)
				writer.WriteStringValue(value.value);
		}
	}
}
