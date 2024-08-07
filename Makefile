run: 
	dotnet run

create-migration:
	dotnet ef migrations add $(name)

execute-migrations:
	dotnet ef database update

execute-in-podman:
	podman-compose down
	podman-compose build
	podman-compose up

execute-in-docker:
	docker compose down
	docker compose build
	docker compose up