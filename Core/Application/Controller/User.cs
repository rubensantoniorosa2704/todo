using TodoApi.Core.Domain.Entities;
using TodoApi.Core.Application.Interfaces;

namespace TodoApi.Core.Application.Controller
{
    public class UserController(IUserService userService)
    {
        private readonly IUserService _userService = userService;

        public async Task<IResult> GetById(int id)
        {
            try
            {
                var foundUser = await _userService.GetById(id);
                return foundUser is not null ? Results.Json(foundUser, statusCode: StatusCodes.Status200OK) : Results.NoContent();
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { ex.Message });
            }
        }

        public async Task<IResult> List()
        {
            try
            {
                var users = await _userService.List();
                
                return Results.Json(users, statusCode: StatusCodes.Status200OK);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { ex.Message });
            }
        }

        public async Task<IResult> Create(User user)
        {
            try
            {
                var createdUser = await _userService.Create(user);
                return createdUser is not null ? Results.Json(createdUser, statusCode: StatusCodes.Status201Created) : throw new ArgumentException();
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { ex.Message });
            }
        }

        public async Task<IResult> Update(User user, int id)
        {
            try
            {
                var updatedUser = await _userService.Update(user, id);
                return updatedUser is not null ? Results.Ok(updatedUser) : throw new ArgumentException();
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { ex.Message });
            }
        }

        public async Task<IResult> Delete(int id)
        {
            try
            {
                var deletedUser = await _userService.Delete(id);
                return deletedUser is not false ? Results.Ok(deletedUser) : throw new ArgumentException();
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { ex.Message });
            }
        }

        public async Task<IResult> GetByEmail(string email)
        {
            try
            {
                var user = await _userService.GetByEmail(email);
                return user is not null ? Results.Ok(user) : Results.NoContent();
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { ex.Message });
            }
        }
    }
}
