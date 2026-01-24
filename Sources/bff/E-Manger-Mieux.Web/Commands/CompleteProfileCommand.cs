
using MediatR;
using Models.Entities;
using Models.Enums;

namespace Commands
{
    public class CompleteProfileCommand : IRequest<Profile>
    {
        public string AuthSubject { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTimeOffset DateOfBirth { get; set; }

        public GenderType Gender { get; set; }

        public decimal Height { get; set; } 

        public decimal Weight { get; set; }
    }
}