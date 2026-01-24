using Commands;
using Models;
using Riok.Mapperly.Abstractions;

namespace E_Manger_Mieux.Web.Mappers;

[Mapper]
public static partial class CompleteProfileDtoMapper
{
    public static CompleteProfileCommand ToCompleteProfileCommand(this CompleteProfileDto command, string authSubject)
    {
        var completeProfileCommand = command.Translate();

        completeProfileCommand.AuthSubject = authSubject;

        return completeProfileCommand;
    }

    [MapperIgnoreTarget(nameof(CompleteProfileCommand.AuthSubject))]
    private static partial CompleteProfileCommand Translate(this CompleteProfileDto command);
}
