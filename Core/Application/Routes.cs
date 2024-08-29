using Microsoft.AspNetCore.Mvc;
using TodoApi.Core.Domain.Entities;
using TodoApi.Core.Application.Controller;

namespace TodoApi.Core.Application
{
    public static class Routing
    {
        public static void MapEndpoints(this WebApplication app)
        {
            app.MapGet("/api/user", async ([FromServices] UserController userController) => await userController.List());
            app.MapGet("/api/user/{id:int}", async ([FromServices] UserController userController, int id) => await userController.GetById(id));
            app.MapGet("/api/user/email/{email}", async ([FromServices] UserController userController, string email) => await userController.GetByEmail(email));
            app.MapPost("/api/user", async ([FromServices] UserController userController, [FromBody] User user) => await userController.Create(user));
            app.MapPut("/api/user/{id}", async ([FromServices] UserController userController, [FromBody] User user, int id) => await userController.Update(user, id));
            app.MapDelete("/api/user/{id:int}", async ([FromServices] UserController userController, int id) => await userController.Delete(id));
        }
    }
}