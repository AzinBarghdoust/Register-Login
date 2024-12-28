//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Infrastructure.SqlServer.Context;
//using MediatR;



//namespace Application.Queries.GetUser
//{
//    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserAccountDto>>
//    {
//        private readonly SqlServerContext _context;

//        public GetAllUsersHandler(SqlServerContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<UserAccountDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
//        {
//            var users = await _context.User
//                .Select(u => new UserDto
//                {
//                    Id = u.Id,
//                    Name = u.Name,
//                    LastName = u.LastName,
//                    Email = u.Email
//                })
//                .ToListAsync(cancellationToken);

//            return users;
//        }
//    }
//}
