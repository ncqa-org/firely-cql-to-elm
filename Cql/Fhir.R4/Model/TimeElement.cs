using Hl7.Cql.Poco.Fhir;
using Hl7.Cql.Iso8601;
using System.Diagnostics;

namespace Hl7.Cql.Poco.Fhir.R4.Model
{
    [DebuggerDisplay("{value}")]
	[FhirUri("http://hl7.org/fhir/StructureDefinition/time")]
	public partial class TimeElement : Element
	{

		public TimeIso8601 value { get; set; }
	}
}
