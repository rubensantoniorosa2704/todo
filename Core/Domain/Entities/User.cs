using TodoApi.GenericEntities;

namespace TodoApi.Core.Domain.Entities {
    public class User : GenericEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

