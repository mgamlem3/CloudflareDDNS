using CloudflareDDNS;

var host = Host.CreateDefaultBuilder(args)
	.UseSystemd()
	.ConfigureServices((hostContext, services) =>
	{
		var configuration = hostContext.Configuration;
		var serviceConfiguration = configuration.GetSection("CloudflareDDNSConfiguration").Get<CloudflareDDNSConfiguration>();
		var domains = configuration
		.GetSection("Domains")
		.Get<List<DnsConfiguration>>();

		if (serviceConfiguration is not null && domains is not null)
		{
			serviceConfiguration.Domains = domains;
			services.AddSingleton(serviceConfiguration);
		}
		else
		{
			throw new ArgumentNullException(nameof(configuration), "Configuration cannot be null");
		}

		services.AddHostedService<CloudflareDDNSService>();
	})
	.Build();

host.Run();
