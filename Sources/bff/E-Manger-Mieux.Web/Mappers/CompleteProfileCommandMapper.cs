using Commands;
using Models.Entities;
using Riok.Mapperly.Abstractions;

namespace Mappers;

[Mapper]
public static partial class CompleteProfileCommandMapper
{
    public static Profile ToProfile(this CompleteProfileCommand command, Profile profile)
    {
        var profileToUpdate = command.Translate();

        profileToUpdate.AvatarUrl = profile.AvatarUrl;

        profileToUpdate.Id = profile.Id;

        profileToUpdate.HeightUnit = profile.HeightUnit;

        profileToUpdate.WeightUnit = profile.WeightUnit;

        profileToUpdate.User = profile.User;

        profileToUpdate.UserId = profile.UserId;

        return profileToUpdate;
    }
        
    [MapperIgnoreTarget(nameof(Profile.AvatarUrl))]
    [MapperIgnoreTarget(nameof(Profile.Id))]
    [MapperIgnoreTarget(nameof(Profile.HeightUnit))]
    [MapperIgnoreTarget(nameof(Profile.WeightUnit))]
    [MapperIgnoreTarget(nameof(Profile.User))]
    [MapperIgnoreTarget(nameof(Profile.UserId))]
    [MapperIgnoreSource(nameof(CompleteProfileCommand.AuthSubject))]
    private static partial Profile Translate(this CompleteProfileCommand command);
}
