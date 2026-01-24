using Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Repositories;

public interface IProfileRepository
{
    Task<Profile?> GetProfileByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Profile> PutProfileAsync(Profile profile, CancellationToken cancellationToken = default);
    Task<Profile?> GetProfileByIdAsync(Guid userId, CancellationToken cancellationToken = default);
}

public class ProfileRepository(ApplicationContext applicationContext) : IProfileRepository
{
    public async Task<Profile?> GetProfileByIdAsync(Guid id, CancellationToken cancellationToken = default) => await applicationContext.Profiles
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == id, cancellationToken);

    public async Task<Profile?> GetProfileByUserIdAsync(Guid userId, CancellationToken cancellationToken = default) => await applicationContext.Profiles
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.UserId == userId, cancellationToken);

    public async Task<Profile> PutProfileAsync(Profile profile, CancellationToken cancellationToken = default) {
        applicationContext.Profiles.Update(profile);
        await applicationContext.SaveChangesAsync();
        return profile;
    }
}