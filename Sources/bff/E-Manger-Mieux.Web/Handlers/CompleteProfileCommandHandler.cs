using Commands;
using Mappers;
using MediatR;
using Models.Entities;
using Repositories;

namespace Handlers;

public class CompleteProfileCommandHandler(IProfileRepository profileRepository, IUserRepository userRepository): IRequestHandler<CompleteProfileCommand, Profile>
{
    public async Task<Profile> Handle(CompleteProfileCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByAuthSubjectAsync(request.AuthSubject, cancellationToken);

        var profile = await profileRepository.GetProfileByUserIdAsync(user!.Id, cancellationToken);
        
        var updatedProfile = await profileRepository.PutProfileAsync(request.ToProfile(profile!), cancellationToken);

        await userRepository.ActivateUser(user.Id, cancellationToken);
    
        return updatedProfile;
    }
}
