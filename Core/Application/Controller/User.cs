using TodoApi.Core.Domain.Entities;
using TodoApi.Core.Domain.Services;

namespace TodoApi.Application.Controller 
{
    public class UserController 
    {
        private readonly UserService _service;

        public UserController() 
        {
            _service = new UserService();
        }

        public async Task <IResult> List()
        {
            List<User> users = (List<User>)await _service.List();

            return Results.Json(users, statusCode: StatusCodes.Status200OK);
        }
    }
}