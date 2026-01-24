using MediatR;
using Models.Entities;

namespace Queries
{
    public class GetUserQuery : IRequest<User>
    {
        public string? AuthSubject { get; set; }
    }
}