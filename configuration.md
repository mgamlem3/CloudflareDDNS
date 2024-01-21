# 🔧 Configuration

## Overview

There are only a few values that you must change or add to run this project. Those are the ones we will talk about here. All configuration goes in `appsettings.json` If you want to know more about the configuration options, see the [Configuration Reference](configuration-reference.md).

## Cloudflare Authentication

Make sure you update these values so that the application can talk to Cloudflare

### CloudflareApiKey

This is where your API token from earlier is entered.

## Domain Configuration

This is where you will enter the details of the DNS record you wish to add or update. Below is an example...

{% code title="appsettings.json" %}
```json
...
"Domains": [
	{
		"Type": "A",
		"Name": "example.com",
		"TTL": 3400,
		"Proxied": true,
		"ZoneIdentifier": "",
		"RecordIdentifier": ""
	}
...
```
{% endcode %}

You can create as many entries as you wish, you must have at least one and all fields are required.

Unfortunately, you need an existing DNS record to update. So, go ahead and create a record in the Cloudflare dashboard for each record you wish to have.

### ZoneIdentifier

This value can be found in the Cloudflare dashboard on the overview tab for your domain. It is labeled "Zone ID." This value will be the same for all domain DNS records.

### RecordIdentifier

Each DNS record you created has a unique identifier. You can go to [https://api.cloudflare.com/#dns-records-for-a-zone-list-dns-records](https://api.cloudflare.com/#dns-records-for-a-zone-list-dns-records) and make a request to the API to get all your DNS record ids.
