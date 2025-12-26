using Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByAuthSubjectAsync(string authSubject, CancellationToken cancellationToken = default);
    Task CreateUserAsync(User user, CancellationToken cancellationToken = default);
}

public class UserRepository(ApplicationContext applicationContext) : IUserRepository
{
    public async Task<User?> GetUserByAuthSubjectAsync(string authSubject, CancellationToken cancellationToken = default) => await applicationContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(t => t.AuthSubject == authSubject, cancellationToken);

    public async Task CreateUserAsync(User user, CancellationToken cancellationToken = default)
    {
        await applicationContext.Users.AddAsync(user, cancellationToken);
        await applicationContext.SaveChangesAsync(cancellationToken);
    }
}