using Microsoft.AspNetCore.Mvc;
using TodoApi.Core.Domain.Entities;
using TodoApi.Core.Infrastructure.Repository;

namespace TodoApi.Core.Domain.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService()
        {
            _repository = new UserRepository();
        }

        public async Task<IActionResult> GetById(int Id)
        {
            if (Id <= 0)
            {
                return new BadRequestObjectResult("Invalid user Id.");
            }

            try
            {
                var user = await _repository.GetById(Id);
                if (user == null)
                {
                    return new NotFoundResult();
                }

                return new OkObjectResult(user);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> List()
        {
            try
            {
                var users = await _repository.List();
                return new OkObjectResult(users);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> Create(User user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Email))
            {
                return new BadRequestObjectResult("User data is invalid.");
            }

            try
            {
                var result = await _repository.Create(user);
                return new CreatedAtActionResult("GetById", "Users", new { Id = user.Id }, user);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> Update(User user)
        {
            if (user == null || user.Id <= 0 || string.IsNullOrWhiteSpace(user.Email))
            {
                return new BadRequestObjectResult("User data is invalid.");
            }

            try
            {
                var existingUser = await _repository.GetById(user.Id);
                if (existingUser == null)
                {
                    return new NotFoundResult();
                }

                await _repository.Update(user);
                return new OkObjectResult(user);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if (Id <= 0)
            {
                return new BadRequestObjectResult("Invalid user Id.");
            }

            try
            {
                var user = await _repository.GetById(Id);
                if (user == null)
                {
                    return new NotFoundResult();
                }

                await _repository.Delete(Id);
                return new NoContentResult();
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return new BadRequestObjectResult("InvalId email address.");
            }

            try
            {
                var user = await _repository.GetByEmail(email);
                if (user == null)
                {
                    return new NotFoundResult();
                }

                return new OkObjectResult(user);
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
