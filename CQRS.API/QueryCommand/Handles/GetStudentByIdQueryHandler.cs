using CQRS.API.Data;
using CQRS.API.QueryCommand.Queries;
using CQRS.API.QueryCommand.Results;

namespace CQRS.API.QueryCommand.Handles
{
    public class GetStudentByIdQueryHandler
    {
        private readonly StudentContext _context;

        public GetStudentByIdQueryHandler(StudentContext context)
        {
            _context = context;
        }

        public GetStudentByIdQueryResult Handle(GetStudentByIdQuery query)
        {
            var student = _context.Set<Student>().Find(query.Id);

            return new GetStudentByIdQueryResult
            {
                Age = student.Age,
                Name = student.Name,
                Surname = student.Surname,
            };
        }
    }
}
