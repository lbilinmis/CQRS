using CQRS.API.QueryCommand.Results;
using MediatR;

namespace CQRS.API.QueryCommand.Queries
{
    public class GetStudentsQuery : IRequest<IEnumerable<GetStudentsQueryResult>>
    {
    }
}
