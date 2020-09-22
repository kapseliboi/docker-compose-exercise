Running `curl localhost:8001` can result in
```Hello from ::ffff:172.21.0.1:59836
to ::ffff:172.21.0.3:80
Hello from ::ffff:172.21.0.3:51628
to ::ffff:172.21.0.2:80```

The first ip address `::ffff:172.21.0.1` is the address of the host operating system inside the virtual network created by docker-compose. The first port number `59836`
is a random port given to the host operating system by docker-compose. This does not match the port the host operating system used when sending the request to docker-compose network.
You can test this by giving `curl` the local port to use, e.g. `--local-port 30001`.

The second ip address `::ffff:172.21.0.3` is the ip address of Service 1 in the docker-compose virtual network and the port number `80` is the port that the service listens to.
In essence the operating system's network address `localhost:8001` is mapped to the virtual network address of `::ffff:172.21.0.3:80`.

The third ip address is again the ip address of Service 1 in the virtual docker-compose network. The port `51628` is just a random port the HTTP client decided to use.
The last ip address `::ffff:172.21.0.2` is the ip addres of Service 2 in the virtual docker-compose network and the port `80` is the port that the service listens to.
