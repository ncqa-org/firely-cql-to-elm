using Hl7.Cql.Poco.Fhir;
using System.Diagnostics.CodeAnalysis;

namespace Hl7.Cql.Poco.Fhir.R4.Model
{
    [FhirUri("http://hl7.org/fhir/StructureDefinition/Narrative")]
	public partial class Narrative : Element
	{

		[NotNull]
		[ValueSetBinding("NarrativeStatus", "http://hl7.org/fhir/ValueSet/narrative-status%7C4.0.1", true)]
		public CodeElement status { get; set; }

		[NotNull]
		public XhtmlElement div { get; set; }
	}
}
