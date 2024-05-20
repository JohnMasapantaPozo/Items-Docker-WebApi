# README - REST API Development

This README file provides an overview of the REST API development process used to create an simple API and its main CRUD operations. Additionally, the README covers how to set up and run a MongoDB in a Docker container, and how to implement asynchronous programming using the "async all the way" pattern.

## Getting Started
To get started, follow the steps outlined below:

1. Clone the repository to your local machine.
2. Install the required dependencies.
3. Create a MongoDB instance either via Docker container or a cloud service provider.
4. Configure your MongoDB instance with your preferred security settings (e.g. authentication).
5. Open the appsettings.Development.json configuration file and update the MongoDB server connection string to match the connection details of your MongoDB instance.

## Development Process

During the development process, the following steps were followed:

1. Modeling the data entity - C# record types were used to define the structure of the API's data entity.
2. Implementing an in-memory repository - An in-memory repository was implemented to store and retrieve resources.
3. Implementing a controller with GET routes - A controller was implemented to allow clients to retrieve data resources.
4. Replace the in-memory repository by a MongoDB instance via Docker - A MongoDB instance was set up using Docker. A Dockerfile and docker-compose.yml file were used to set up the instance.
5. Enabling authentication in the MongoDB instance and configuring it in the API - Authentication was enabled in the MongoDB instance and configured in the API using .NET Secret Manager.
6. Implementing asynchronous programming - Asynchronous programming was implemented using the "async all the way" pattern.
7. Implementing health checks - Health checks were implemented to ensure that the API and dependencies were working correctly.
8. Deploying the API as a Docker container - The API was deployed as a Docker container, and the MongoDB instance was also set up as a Docker container.
9. Configuring Kubernetes and deploying the API to it - Kubernetes was set up, and the API was deployed to the Kubernetes cluster.

## Deploying the API

To deploy the API to a production environment, follow the steps below:

1. Create a Docker image of the API using the docker build command.
2. Push the Docker image to a Docker registry (e.g. Docker Hub or Amazon ECR).
3. Set up a Kubernetes cluster on your preferred cloud service provider (e.g. Google Kubernetes Engine, Amazon EKS).
4. Deploy the API to the Kubernetes cluster using a .yaml configuration file

See Dev-notes.md for more detailed information.