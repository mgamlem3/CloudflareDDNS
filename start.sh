docker run \
    -it \
    -d \
    --network bridge \
    --name CloudflareDDNS \
    --restart on-failure:3 \
    cloudflare-ddns:latest
