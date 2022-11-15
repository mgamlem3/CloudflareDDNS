namespace CloudflareDDNS;

public class CloudflareDDNSServiceException : Exception
{
	public CloudflareDDNSServiceException() { }

	public CloudflareDDNSServiceException(string message) : base(message) { }

	public CloudflareDDNSServiceException(string message, Exception innerException) : base(message, innerException) { }
}
