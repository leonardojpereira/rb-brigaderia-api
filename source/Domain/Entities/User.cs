using BCrypt.Net;

namespace Project.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;  

        public string Username { get; private set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid RoleId { get; set; }    
        public virtual Role? Role { get; set; }

        private User( ) { }

        public User(string nome, string username, string password, string email, Guid roleId)
        {
            Nome = nome;
            Username = username;
            HashedPassword = HashPassword(password);
            Email = email;
            RoleId = roleId;
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, HashedPassword);
        }
    }
}
