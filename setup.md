# ⚙ Setup

## Pre-Requisites

These instructions assume you have already added your domain to Cloudflare and are using their DNS servers. If you haven't done that yet check out [this help article](https://developers.cloudflare.com/fundamentals/get-started/setup/add-site/) to get you started. Come back over here when you are done.

## Prepare your computer or VM

This project is a .NET project running inside a Docker container. This is so that the configuration on the machine where this project will run is minimal.&#x20;

{% hint style="info" %}
If you don't want to use Docker and would prefer to compile and run the code on your machine, you will need to install the .[NET SDK used by the Docker container](https://github.com/mgamlem3/CloudflareDDNS/blob/af6e15f74ebe88d331e159afdf7423538a40091d/Dockerfile#L1). You can skip to [getting your API token from Cloudflare.](setup.md#get-cloudflare-api-token)
{% endhint %}

### Install Docker

Installing Docker is the easiest way to run this project. Instructions for how to do that for your OS can be found [here](https://docs.docker.com/get-docker/).

### Get the code

The easiest way to do this is to use [git](https://git-scm.com/downloads) to clone the code from GitHub. Just run the following command in the directory where you want the code.

```
git clone https://github.com/mgamlem3/CloudflareDDNS.git
```

You could also [download](https://github.com/mgamlem3/CloudflareDDNS/archive/refs/heads/main.zip) the code as a .zip and unzip it on your machine if you prefer.

## Get Cloudflare API Token

You will need an API token to authenticate to the Cloudflare API.

Head over to [https://dash.cloudflare.com/profile/api-tokens](https://dash.cloudflare.com/profile/api-tokens) and create a token with the **DNS:Edit** permission for your domain's zone.

Make a note of this token so you can add it to the configuration file.
