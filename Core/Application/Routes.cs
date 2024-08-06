using Microsoft.AspNetCore.Mvc;
using TodoApi.Application.Controller;

public static class Routing {
    public static void MapEndpoints(this WebApplication app) {
        UserController userController = new();

        app.MapGet("/user", async () => await userController.List());
    }
}