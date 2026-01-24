using MediatR;
using Models.Entities;
using Queries;
using Repositories;

namespace Handlers
{
    public class GetProfileHandler(IProfileRepository profileRepository, IUserRepository userRepository) : IRequestHandler<GetProfileQuery, Profile>
    {
        public async Task<Profile> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserByAuthSubjectAsync(request.AuthSubject, cancellationToken);
            
            var profile = await profileRepository.GetProfileByUserIdAsync(user.Id, cancellationToken);

            return profile;
        }
    }
}