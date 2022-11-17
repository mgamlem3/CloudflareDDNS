using CloudflareDDNS.CloudlfareApi.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CloudflareDDNS.CloudlfareApi.Dtos;

public class CloudflareDnsRecordRequest
{
	public CloudflareDnsRecordRequest(string type, string name, string content, uint ttl, uint? priority = null, bool? proxied = null) => (Type, Name, Content, TTL, Priority, Proxied) = (type, name, content, ttl, priority, proxied);

	/// <summary>
	/// DNS record type.
	/// </summary>
	[Attributes.DnsRecordType]
	[Required]
	public string Type { get; set; }
	/// <summary>
	/// DNS record name (or @ for the zone apex).
	/// </summary>
	[Url]
	[MaxLength(255)]
	[Required]
	public string Name { get; set; }
	/// <summary>
	/// DNS record content.
	/// </summary>
	[IpAddress]
	[Required]
	public string Content { get; set; }
	/// <summary>
	/// Time to live, in seconds, of the DNS record. Must be between 60 and 86400, or 1 for 'automatic'.
	/// </summary>
	[TTL]
	[Required]
	public uint TTL { get; set; }
	/// <summary>
	/// Required for MX, SRV and URI records; unused by other record types. Records with lower priorities are preferred.
	/// </summary>
	[Range(0, 65535, ErrorMessage = "Must be between 0 and 65535")]
	public uint? Priority { get; set; }
	/// <summary>
	/// Whether the record is receiving the performance and security benefits of Cloudflare.
	/// </summary>
	public bool? Proxied { get; set; }
}
