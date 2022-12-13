# CloudflareDDNS

## Description

Cloudflare does not have an easy way to update DNS records if your public address changes regularly. This service will check for your public ip address at a configurable interval and use the Cloudflare Api to update DNS records. Effectively this will give you DDNS using Cloudflare nameservers.

This project uses .NET 7, C#, and Docker.

## Usage

This project runs as a Docker container. Scripts to build and start the container are included in the repository. Clone this repo, edit the configuration, build, and then start the container.

## Configuration

Take a look at the [example configuration file](https://github.com/mgamlem3/CloudflareDDNS/blob/main/appsettings.json) in this repo. All configuration should be in `appsettings.json`.

### CloudflareDDNSConfiguration

#### CloudflareApiBaseUri:

This is the endpoint that the service will use. Currently this should Cloudflare api v4.

#### CloudflareAuthEmail:

Email associated with auth token

#### CloudflareApiKey:

Sometimes called the "Global API Key" this can be accessed in the Cloudflare portal.

#### CloudflareTimeoutSeconds:

Amount of time to wait for a response from Cloudflare Api in seconds

#### UpdateFrequency:

Number of units to wait between updates

#### UpdateFrequencyUnit:

Units to use with above number when waiting between updates. Valid options are `second`, `minute`, and `hour`. Any case may be used in the json file. Plurals may also be used.

### Domains

This must be an array of objects conforming to the below shape.

#### Type:

Type of DNS record. Must be a valid DNS record type.

#### Name:

Domain name to add to DNS record

#### TTL:

Time to live for the DNS record. Cloudflare enforces this as a number between **60** and **86400** or **1** for automatic.

#### Proxied:
Should this record proxy through Cloudflare? true or false

#### ZoneIdentifier:

Unique identifier for your DNS zone. This can be found in the Cloudflare portal.

#### RecordIdentifier:

Unique identifier for your DNS record. This can also be found on the cloudflare portal.
