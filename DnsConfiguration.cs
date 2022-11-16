namespace CloudflareDDNS;

public class DnsConfiguration
{
	public DnsConfiguration(string type, string name, int ttl) => (Type, Name, TTL) = (type, name, ttl);

	public string Type { get; set; }
	public string Name { get; set; }
	public int TTL { get; set; }
}
