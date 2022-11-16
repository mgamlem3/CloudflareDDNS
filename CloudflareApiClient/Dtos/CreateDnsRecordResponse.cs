using System.Diagnostics.CodeAnalysis;

namespace CloudflareDDNS.CloudlfareApiClient.Dtos;

public class CreateDnsRecordResponse
{
	public bool Success { get; set; }
	[SuppressMessage("return types", "CA1819", Justification = "Cloudflare docs do not specify type of this property")]
	public object[]? Errors { get; set; }
	[SuppressMessage("return types", "CA1819", Justification = "Cloudflare docs do not specify type of this property")]
	public object[]? Messages { get; set; }
	public CloudflareDnsRecord? Result { get; set; }
}
