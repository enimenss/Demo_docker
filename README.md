# .Net Core, Nignx, Redis and Docker

This is simple aplication that increments counter stored on Redis. Application is consists of three parts: 

  1. .Net Core application
  2. Nignx
  3. Redis database
  
Currently in this demo project there is three instances of .Net core application running on kestrel server, 
and one instance of Redis database, those services all run independently with possibility to add more and scale application.
All services mention above are wraped behind using Nignx service, which will provide load balancing for .Net application instances. 


## Start
```
sudo docker-compose up
```

```
curl localhost/api/values // test

["Site has been visited:1"] // response

curl localhost/api/values // test

["Site has been visited:2"] // response
...
