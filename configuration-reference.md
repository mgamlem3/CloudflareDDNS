# 🕵♀ Configuration Reference

## Overview

Below are the details of the JSON configuration object for the project. All configuration goes in `appsettings.json`.

## CloudflareDDNSConfiguration:

### **CloudflareApiBaseUri:**

This is the endpoint that the service will use. Currently this should Cloudflare API v4.

### **CloudflareAuthEmail:**

Email associated with the API key

### **CloudflareApiKey:**

This can be created in the Cloudflare portal. It must have the **DNS:Edit** permission.

### **CloudflareTimeoutSeconds:**

Amount of time to wait for a response from Cloudflare API in seconds

### **UpdateFrequency:**

Number of units to wait between updates

### **UpdateFrequencyUnit:**

Units to use with above number when waiting between updates. Valid options are `second`, `minute`, and `hour`. Any case may be used in the json file. Plurals may also be used.

## Domains

This must be an array of objects conforming to the below shape

### **Type:**

Type of DNS record. Must be a valid DNS record type

### **Name:**

Domain name to add to DNS record

### **TTL:**

Time to live for the DNS record. Cloudflare enforces this as a number between **60** and **86400** or **1** for automatic.

### **Proxied:**

Should this record proxy through Cloudflare? `true` or `false`

### **ZoneIdentifier:**

Unique identifier for your DNS zone. This can be found in the Cloudflare portal.

### **RecordIdentifier:**

Unique identifier for your DNS record. This can also be found using the Cloudflare API.
