# 👋 Welcome

## What is this project?

Cloudflare does not have an easy way to update DNS records if your public address changes regularly. This is common for many home internet connections becuase they do not have a static IP address. This project will check for your public ip address at a configurable interval and use the Cloudflare API to update your DNS record for your domain as needed.

## Who is this for?

Anyone who is using Cloudflare as a DNS provider and does not have a static IP address

## What do I need to get started?

1. Domain
2. Cloudflare account
3. Internet connection
4. Computer/VM capable of running a Docker container
