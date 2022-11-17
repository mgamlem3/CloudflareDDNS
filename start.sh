docker run \
    -it \
    -d \
    --rm \
    --network bridge \
    --name CloudflareDDNS \
    cloudflare-ddns:latest
