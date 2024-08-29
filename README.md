# Todo API

**A C# API built following Domain-Driven Design (DDD) principles.**

## Getting Started

### Prerequisites
* Docker and Docker Compose installed

### Running the application
To run the application using Docker Compose, execute the following commands in your terminal:
```bash
docker compose down
docker compose build
docker compose up
```

## Project Structure

- Domain: Contains the core domain model, entities, value objects, and aggregates.

- Application: Handles application services, use cases, and orchestrates the domain.

- Infrastructure: Provides the technical implementation, such as database access (using Entity Framework), external services, and adapters.

## Contributing
Want to contribute? Great!

- Fork the repository.
- Create a new branch for your feature: ``git checkout -b feature-name``

- Make your changes and commit them: ``git commit -m 'Your commit message'``

- Push to your fork: ``git push origin feature-name``

- Create a pull request from your branch to the upstream repository.

## Contributors
A huge thanks for those who are helping me with this project in some way.
- [Luan Vendrami (Software Developer)](https://github.com/luanvendrami)