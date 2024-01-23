### Documentation

```text
    1. How to model an entity via C# record types.
    2. How to implement and in memory repository of resources.
    3. How to implement a controler with GET routes to retrieve resources.
    4. How to implement a simple MongoDB
```
```text
    5. How to run a MongoDB in a docker container
```

```shell
        # Spin up a database without authentication enabled
        docker run -d --rm --name mongo  -p 27017:27017 -v
        docker ps
        docker stop mongo
        docker volume ls
```
```text
    6. Tasks, Async, and Wait in .NET: Asynchronous Programing
        In our context we will implement an "Async all the way" strategy.
        User -> Controller -> DataRepository -> Database (All -> are async)

    7. Secret Manegement (.NET secret manager).
        By enabling user/password in the database we require to let the API know how to use those values.
```
```shell
        # Spin up a database with authentication enabled
        # -> Update the service to make it aware about authentication.
        docker run -d --rm --name mongo -p 27017:27017 -v mongo:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=password123 mongo

        # Setting admin password in the .NET secrets manager
        dotnet user-secrets init
        dotnet user-secrets set MongoDbConfig:Password password123
```
```text
    8. API and API dependancies healt checks.
        New endpoint added to provide the API health status.
        Common healt checks include: /health, /health/ready, health/live.
```
```shell
        # Let's use this open source package to health check our database connection.
        dotnet add package AspNetCore.HealthChecks.MongoDb
```
```text
    9. Challenges of deployment.
    10. Turn REST API into a Docker Image.
    11. Run a REST API as a Dokcer Container.
        
        Two docker images/containers to be created ans spinned up.
        One for the API and another one for the database.
        They will communicate througth a docker network.

        Docker hub to be used to publish the docker image.
```

```shell
        # Create docker image for the REST API
        docker build -t webapidemo:v1 .
        
        # Create a network
        docker network create webapinet
        docker network ls

        # Spin up the database container and joing the network
        docker run -d --rm --name mongo -p 27017:27017 -v mongo:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=password123 --network=webapinet mongo

        # Spin up the API container and join the network
        docker run -it --rm -p 8080:80 -e MongoDbConfig:Host=mongo -e MongoDbConfig:Password=password123 --network=webapinet webapidemo:v1
```