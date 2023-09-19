using CQRS.API.Data;
using CQRS.API.QueryCommand.Queries;
using CQRS.API.QueryCommand.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.API.QueryCommand.Handles
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<GetStudentsQueryResult>>
    {
        private readonly StudentContext _context;

        public GetStudentsQueryHandler(StudentContext context)
        {
            _context = context;
        }

      

        public IEnumerable<GetStudentsQueryResult> Handle(GetStudentsQuery query)
        {
            var students = _context.Students.Select(x => new GetStudentsQueryResult
            {
                Age = x.Age,
                Name = x.Name,
                Surname = x.Surname

            }).AsNoTracking().AsEnumerable();

            return students;
        }

        public async Task<IEnumerable<GetStudentsQueryResult>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _context.Students.Select(x => new GetStudentsQueryResult
            {
                Age = x.Age,
                Name = x.Name,
                Surname = x.Surname

            }).AsNoTracking().ToListAsync();

            return students;
        }
    }
}
