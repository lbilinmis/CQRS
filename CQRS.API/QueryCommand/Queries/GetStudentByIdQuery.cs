using CQRS.API.QueryCommand.Results;
using MediatR;

namespace CQRS.API.QueryCommand.Queries
{
    public class GetStudentByIdQuery : IRequest<GetStudentByIdQueryResult>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
