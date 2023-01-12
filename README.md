# CloudflareDDNS

## Description

Cloudflare does not have an easy way to update DNS records if your public address changes regularly. This service will check for your public ip address at a configurable interval and use the Cloudflare Api to update DNS records. Effectively this will give you DDNS using Cloudflare nameservers.

This project uses .NET 7, C#, and Docker.

Read the documentation at https://mg3.gitbook.io/cloudflare-ddns/
