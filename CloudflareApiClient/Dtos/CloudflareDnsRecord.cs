namespace CloudflareDDNS.CloudlfareApi.Dtos;

public sealed class CloudflareDnsRecord
{
	public CloudflareDnsRecord(string id, string type, string name, string content, bool proxiable, bool proxied, uint ttl, bool locked, string zoneId, string zoneName, string createdOn, string modifiedOn, object? data, CloudflareDnsRecordMetadata meta) => (Id, Type, Name, Content, Proxiable, Proxied, TTL, Locked, ZoneId, ZoneName, CreatedOn, ModifiedOn, Data, Meta) = (id, type, name, content, proxiable, proxied, ttl, locked, zoneId, zoneName, createdOn, modifiedOn, data, meta);

	public string Id { get; set; }
	public string Type { get; set; }
	public string Name { get; set; }
	public string Content { get; set; }
	public bool Proxiable { get; set; }
	public bool Proxied { get; set; }
	public uint TTL { get; set; }
	public bool Locked { get; set; }
	public string ZoneId { get; set; }
	public string ZoneName { get; set; }
	public string CreatedOn { get; set; }
	public string ModifiedOn { get; set; }
	public object? Data { get; set; }
	public CloudflareDnsRecordMetadata Meta { get; set; }

	public sealed class CloudflareDnsRecordMetadata
	{
		public CloudflareDnsRecordMetadata(bool autoAdded, string source) => (AutoAdded, Source) = (autoAdded, source);

		public bool AutoAdded { get; set; }
		public string Source { get; set; }
	}
}
