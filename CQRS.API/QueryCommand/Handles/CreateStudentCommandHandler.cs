using CQRS.API.Data;
using CQRS.API.QueryCommand.Commands;

namespace CQRS.API.QueryCommand.Handles
{
    public class CreateStudentCommandHandler
    {
        private readonly StudentContext _context;

        public CreateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }

        public void Handle(CreateStudentCommand command)
        {
            _context.Students.Add(new Student()
            {
                Age = command.Age,
                Name = command.Name,
                Surname = command.Surname
            });

            _context.SaveChanges();
        }
    }
}
