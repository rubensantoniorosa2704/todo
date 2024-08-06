using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TodoApi.Core.Domain.Entities;

namespace TodoApi.Core.Infrastructure.Dao {
    public class UserDao
    {
        private readonly SQLServerAdapter<User> _sql;

        public UserDao()
        {
            _sql = new SQLServerAdapter<User>(EnvironmentVariables.DBString);
        }

        public Task<User?> GetById(int id)
        {
            return _sql.Get<User>(
                "SELECT Id, Name, Email, Password, CreationDate, LastUpdatedDate, DeletionDate FROM User WHERE Id = @id;",
                [
                    new SqlParameter("@id", SqlDbType.Int) { Value = id }
                ]
            );
        }

        public Task<List<User>> List()
        {
            return _sql.List<User>(
                "SELECT Id, Name, Email, Password, CreationDate, LastUpdatedDate, DeletionDate FROM User;"
            );
        }

        public Task<IActionResult> Create(User user)
        {
            return _sql.Execute(
                "INSERT INTO User (Name, Email, Password, CreationDate) VALUES (@name, @email, @password, @creationDate);",
                [
                    new SqlParameter("@name", SqlDbType.NVarChar) { Value = user.Name },
                    new SqlParameter("@email", SqlDbType.NVarChar) { Value = user.Email },
                    new SqlParameter("@password", SqlDbType.NVarChar) { Value = user.Password },
                    new SqlParameter("@creationDate", SqlDbType.DateTime) { Value = user.CreationDate }
                ]
            );
        }

        public Task<IActionResult> Update(User user)
        {
            return _sql.Execute(
                "UPDATE User SET Name = @name, Email = @email, Password = @password, LastUpdatedDate = @lastUpdatedDate WHERE Id = @id;",
                [
                    new SqlParameter("@id", SqlDbType.Int) { Value = user.Id },
                    new SqlParameter("@name", SqlDbType.NVarChar) { Value = user.Name },
                    new SqlParameter("@email", SqlDbType.NVarChar) { Value = user.Email },
                    new SqlParameter("@password", SqlDbType.NVarChar) { Value = user.Password },
                    new SqlParameter("@lastUpdatedDate", SqlDbType.DateTime) { Value = user.LastUpdatedDate }
                ]
            );
        }

        public Task<IActionResult> Delete(int id)
        {
            return _sql.Execute(
                "DELETE FROM User WHERE Id = @id;",
                [
                    new SqlParameter("@id", SqlDbType.Int) { Value = id }
                ]
            );
        }

        public Task<User?> GetByEmail(string email)
        {
            return _sql.Get<User>(
                "SELECT Id, Name, Email, Password, CreationDate, LastUpdatedDate, DeletionDate FROM User WHERE Email = @email;",
                [
                    new SqlParameter("@email", SqlDbType.NVarChar) { Value = email }
                ]
            );
        }
    }
}