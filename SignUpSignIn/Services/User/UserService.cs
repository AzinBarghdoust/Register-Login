using Domain.Entities;
using Infrastructure.SqlServer.Context;
using Microsoft.AspNetCore.Identity;
using SignUpSignIn.DTOs.User;

namespace SignUpSignIn.Services.User
{
    public class UserService
    {
        private readonly SqlServerContext _context;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;
        public UserService(SqlServerContext context, IPasswordHasher<UserEntity> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public async Task<bool> RegisterUser(RegistrationUserDto dto)
        {
            if (_context.User.Any(m => m.Email == dto.Email))
                throw new Exception("Email already exists.");

            var passwordHash = _passwordHasher.HashPassword(null, dto.Password);

            var user = new UserEntity
            {
                Email = dto.Email,
                Name = dto.Name,
                LastName = dto.LastName,
                PasswordHash = passwordHash
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
