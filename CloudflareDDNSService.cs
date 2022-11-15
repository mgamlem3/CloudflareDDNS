using System.Net;

namespace CloudflareDDNS;

public class CloudflareDDNSService : BackgroundService
{
	public CloudflareDDNSService(ILogger<CloudflareDDNSService> logger, CloudflareDDNSConfiguration configuration)
	{
		m_logger = logger;
		m_configuration = configuration;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		m_logger.LogInformation("Worker started at: {time}", DateTimeOffset.Now);
		await Initialize();
		while (!stoppingToken.IsCancellationRequested)
		{
			var ip = await GetPublicIPAddress();
			m_logger.LogInformation("IP: {ip}", ip);
		}
	}

	private async Task Initialize()
	{
		m_logger.LogInformation("Initializing service...");

		try
		{
			m_configuration.CheckConfigurationIsValid();
			await CloudflareIsReachable();
		}
		catch (CloudflareDDNSServiceException e)
		{
			m_logger.LogError("Unable to initialize service: ", e);
		}
	}

	/// <summary>
	/// Check to see if CloudflareApi is reachable
	/// </summary>
	/// <returns>true if reachable, false otherwise</returns>
	/// <exception cref="CloudflareDDNSServiceException">Thrown when failure status code is returned from HttpClient request</exception>
	private async Task<bool> CloudflareIsReachable()
	{
		try
		{
			using var cancellationTokenSource = new CancellationTokenSource(new TimeSpan(0, 0, m_configuration.CloudflareTimeoutSeconds));
			var response = await new HttpClient().GetAsync(m_configuration.GetCloudflareApiUri(), cancellationTokenSource.Token).ConfigureAwait(false);

			if (response.IsSuccessStatusCode)
				return true;
			else
				throw new CloudflareDDNSServiceException("Failed to connect to CloudflareApi");
		}
		catch (HttpRequestException e)
		{
			m_logger.LogError("Error checking Cloudflare reachability: ", e);
		}

		return false;
	}

	/// <summary>
	/// Get public ip from where service is running
	/// </summary>
	/// <returns>IPAddress if found, null otherwise</returns>
	private async Task<IPAddress?> GetPublicIPAddress()
	{
		try
		{
			using var client = new HttpClient();
			using var response = await client.GetAsync("https://ipinfo.io/ip");
			var ipString = await response.Content.
			ReadAsStringAsync();

			if (!string.IsNullOrWhiteSpace(ipString))
				return IPAddress.Parse(ipString);
		}
		catch (HttpRequestException e)
		{
			m_logger.LogError("Error fetching IPAddress: ", e);
		}
		catch (FormatException e)
		{
			m_logger.LogError("FormatException while trying to format IPAddress: ", e);
		}

		return null;
	}

	private readonly ILogger<CloudflareDDNSService> m_logger;
	private readonly CloudflareDDNSConfiguration m_configuration;
}
