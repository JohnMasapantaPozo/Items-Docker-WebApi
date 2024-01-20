### Documentation

```text
    - How to model an entity via C# record types.
    - How to implement and in memory repository of resources.
    - How to implement a controler with GET routes to retrieve resources.
    - How to implement a simple MongoDB
    - How to run a MongoDB in a docker container
    - Tasks, Async, and Wait in .NET: Asynchronous Programing
        In our context we will implement an "Async all the way" strategy.
        User -> Controller -> DataRepository -> Database (All -> are async)
```

```shell
docker run -d --rm --name mongo  -p 27017:27017 -v
docker ps
```
    