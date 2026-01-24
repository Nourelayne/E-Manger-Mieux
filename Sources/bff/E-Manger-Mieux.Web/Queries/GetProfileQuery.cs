using MediatR;
using Models.Entities;

namespace Queries
{
    public class GetProfileQuery : IRequest<Profile>
    {
        public string? AuthSubject { get; set; }
    }
}