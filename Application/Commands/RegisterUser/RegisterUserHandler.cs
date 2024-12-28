using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.User;
using Domain.Entities;
using Infrastructure.SqlServer.Context;
using MediatR;

namespace Application.Commands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly SqlServerContext _context;

        public RegisterUserHandler(SqlServerContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Password != request.ConfirmPassword)
            {
                throw new Exception("Passwords do not match.");
            }

            if (_context.User.Any(m => m.Email == request.Email))
            {
                throw new Exception("Email is already in use.");
            }

            var user = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };
                _context.User.Add(user);
                await _context.SaveChangesAsync(cancellationToken);
                    return "User Registered Successfully";
        }
    }
}
