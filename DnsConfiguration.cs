namespace CloudflareDDNS;

public class DnsConfiguration
{
	public string Type { get; set; }
	public string Name { get; set; }
	public int TTL { get; set; }
	public bool Proxied { get; set; }
	public string ZoneIdentifier { get; set; }
	public string RecordIdentifier { get; set; }

	public bool IsValid()
	{
		if (Type is null)
			return false;
		else if (Name is null)
			return false;
		else if (string.IsNullOrWhiteSpace(ZoneIdentifier))
			return false;
		else if (string.IsNullOrWhiteSpace(RecordIdentifier))
			return false;
		else
			return true;
	}
}
