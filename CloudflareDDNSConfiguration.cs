using Mg3.Utility.StringUtility;

namespace CloudflareDDNS;

public class CloudflareDDNSConfiguration
{
	public CloudflareDDNSConfiguration(string cloudflareApiBaseUri, string cloudflareAuthEmail, string cloudflareApiKey, int cloudflareTimeoutSeconds, int updateFrequency, string updateFrequencyUnit, List<DnsConfiguration>? domains = null) => (CloudflareApiBaseUri, CloudflareAuthEmail, CloudflareApiKey, CloudflareTimeoutSeconds, Domains, UpdateFrequency, UpdateFrequencyUnit) = (cloudflareApiBaseUri, cloudflareAuthEmail, cloudflareApiKey, cloudflareTimeoutSeconds, domains, updateFrequency, updateFrequencyUnit);

	public string CloudflareApiBaseUri { get; init; }
	public string CloudflareAuthEmail { get; set; }
	public string CloudflareApiKey { get; set; }
	public int CloudflareTimeoutSeconds { get; init; }
	public List<DnsConfiguration>? Domains { get; set; }
	public int UpdateFrequency { get; init; }
	public string UpdateFrequencyUnit { get; init; }

	/// <summary>
	/// Checks to see if required configuation values are present
	/// </summary>
	/// <exception cref="CloudflareDDNSServiceException">Thrown when value is missing. Contains details of missing value</exception>
	public void CheckConfigurationIsValid()
	{
		if (CloudflareApiBaseUri.IsNullOrWhitespace())
		{
			throw new CloudflareDDNSServiceException("Cloudflare base uri is required");
		}
		else if (Domains is null || !Domains.Any())
		{
			throw new CloudflareDDNSServiceException("No domains were provided");
		}
		else if (Domains.Any(x =>
		{
			if (!x.Name.IsNullOrWhitespace() || !x.RecordIdentifier.IsNullOrWhitespace() || !x.Type.IsNullOrWhitespace() || !x.ZoneIdentifier.IsNullOrWhitespace())
				return true;
			else
				return false;
		}))
		{
			throw new CloudflareDDNSServiceException("Domain information was incomplete");
		}
	}

	/// <summary>
	/// Get Cloudflare url as System.Uri
	/// </summary>
	/// <returns>Uri</returns>
	public Uri GetCloudflareApiUri() => new(CloudflareApiBaseUri);

	/// <summary>
	/// Get TimeSpan to represent update frequency desired. Will return default 1 hour if no timespan unit was specified in config
	/// </summary>
	/// <returns>TimeSpan</returns>
	public TimeSpan GetUpdateFrequencyTimeSpan() => UpdateFrequencyUnit.ToUpperInvariant() switch
	{
		"SECOND" or "SECONDS" => new TimeSpan(0, 0, UpdateFrequency),
		"MINUTE" or "MINUTES" => new TimeSpan(0, UpdateFrequency, 0),
		"HOUR" or "HOURS" => new TimeSpan(UpdateFrequency, 0, 0),
		_ => new TimeSpan(1, 0, 0),
	};
}
