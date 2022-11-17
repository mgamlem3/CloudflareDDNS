namespace CloudflareDDNS.CloudlfareApi;

public class CloudflareApiClientException : Exception
{
	public CloudflareApiClientException() { }

	public CloudflareApiClientException(string message) : base(message) { }

	public CloudflareApiClientException(string message, Exception innerException) : base(message, innerException) { }
}
