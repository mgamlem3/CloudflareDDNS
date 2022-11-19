namespace CloudflareDDNS;

public class DnsConfiguration
{
	public DnsConfiguration(string type, string name, int ttl, bool proxied, string zoneIdentifier, string recordIdentifier) => (Type, Name, TTL, Proxied, ZoneIdentifier, RecordIdentifier) = (type, name, ttl, proxied, zoneIdentifier, recordIdentifier);

	public string Type { get; set; }
	public string Name { get; set; }
	public int TTL { get; set; }
	public bool Proxied { get; set; }
	public string ZoneIdentifier { get; set; }
	public string RecordIdentifier { get; set; }
}
