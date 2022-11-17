namespace CloudflareDDNS;

public class DnsConfiguration
{
	public DnsConfiguration(string type, string name, int ttl, string zoneIdentifier, string recordIdentifier) => (Type, Name, TTL, ZoneIdentifier, RecordIdentifier) = (type, name, ttl, zoneIdentifier, recordIdentifier);

	public string Type { get; set; }
	public string Name { get; set; }
	public int TTL { get; set; }
	public string ZoneIdentifier { get; set; }
	public string RecordIdentifier { get; set; }
}
