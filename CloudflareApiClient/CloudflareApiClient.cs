using CloudflareDDNS.CloudlfareApi.Dtos;
using Mg3.Utility.StringUtility;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using System.Text;

namespace CloudflareDDNS.CloudlfareApi;

public class CloudlfareApiClient
{
	public CloudlfareApiClient(CloudflareDDNSConfiguration configuration, ILogger<CloudflareDDNSService> logger)
	{
		m_cloudflareDDNSConfiguration = configuration;
		m_logger = logger;
		ConfigureHttpClient();
	}

	/// <summary>
	/// Make request to Cloudflare api to update DNS record
	/// </summary>
	/// <param name="request"></param>
	/// <param name="ipAddress"></param>
	/// <returns></returns>
	/// <exception cref="CloudflareApiClientException"></exception>
	public async Task<UpdateDnsRecordResponse> UpdateDnsRecord(DnsConfiguration request, string ipAddress)
	{
		if (request is null)
			throw new ArgumentNullException(nameof(request));
		else if (!request.IsValid())
			throw new CloudflareApiClientException("Request was invalid.");

		try
		{
			var json = JsonConvert.SerializeObject(new CloudflareDnsRecordRequest(request.Type, request.Name, ipAddress, (uint) request.TTL, proxied: request.Proxied), s_jsonSerializerSettings);
			var putRequest = new HttpRequestMessage(HttpMethod.Put, $"zones/{request.ZoneIdentifier}/dns_records/{request.RecordIdentifier}")
			{
				Content = new StringContent(json, Encoding.UTF8, new MediaTypeHeaderValue("application/json"))
			};
			var response = await m_httpClient.SendAsync(putRequest);

			if (response is null || response.Content is null)
				throw new CloudflareApiClientException("Response or response content was null from cloudflare.");

			var stringafiedResponseContent = await response.Content.ReadAsStringAsync();

			if (stringafiedResponseContent.IsNullOrWhitespace())
				return new UpdateDnsRecordResponse() { Success = false, Errors = new string[] { "Response content could not be converted to string" } };

			var deserializedResponse = JsonConvert.DeserializeObject<UpdateDnsRecordResponse>(stringafiedResponseContent);

			if (deserializedResponse is null)
				return new UpdateDnsRecordResponse() { Success = false, Errors = new string[] { "Unable to deserialize response content" } };

			return deserializedResponse;
		}
		catch (Exception e)
		{
			if (e is HttpRequestException || e is CloudflareApiClientException)
				m_logger.LogError("Error updating DNS record: ", e);
			else
				throw;
		}

		throw new CloudflareApiClientException("Unexpected error");
	}

	private void ConfigureHttpClient()
	{
		m_httpClient.BaseAddress = m_cloudflareDDNSConfiguration.GetCloudflareApiUri();
		m_httpClient.DefaultRequestHeaders.Add("X-Auth-Email", m_cloudflareDDNSConfiguration.CloudflareAuthEmail);
		m_httpClient.DefaultRequestHeaders.Add("X-Auth-Key", m_cloudflareDDNSConfiguration.CloudflareApiKey);
	}

	private CloudflareDDNSConfiguration m_cloudflareDDNSConfiguration { get; init; }
	private ILogger<CloudflareDDNSService> m_logger { get; init; }
	private readonly HttpClient m_httpClient = new();
	private static readonly DefaultContractResolver s_contractResolver = new()
	{
		NamingStrategy = new SnakeCaseNamingStrategy()
	};
	private static readonly JsonSerializerSettings s_jsonSerializerSettings = new()
	{
		ContractResolver = s_contractResolver,
		NullValueHandling = NullValueHandling.Ignore
	};
}
