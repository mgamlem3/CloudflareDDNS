using Mg3.Utility.StringUtility;

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
		else if (ZoneIdentifier.IsNullOrWhitespace())
			return false;
		else if (RecordIdentifier.IsNullOrWhitespace())
			return false;
		else
			return true;
	}
}
