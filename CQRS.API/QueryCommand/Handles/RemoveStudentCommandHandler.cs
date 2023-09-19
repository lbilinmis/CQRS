using CQRS.API.Data;
using CQRS.API.QueryCommand.Commands;

namespace CQRS.API.QueryCommand.Handles
{
    public class RemoveStudentCommandHandler
    {
        private readonly StudentContext _context;

        public RemoveStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }

        public void Handle(RemoveStudentCommand command)
        {
            var deletedStudent=_context.Students.Find(command.Id);
            _context.Students.Remove(deletedStudent);
            _context.SaveChanges();
        }
    }
}
