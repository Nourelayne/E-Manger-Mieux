using MediatR;
using Models.Entities;
using Queries;
using Repositories;

namespace Handlers
{
    public class GetUserHandler(IUserRepository userRepository) : IRequestHandler<GetUserQuery, User>
    {
        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserByAuthSubjectAsync(request.AuthSubject, cancellationToken);

            return user;
        }
    }
}