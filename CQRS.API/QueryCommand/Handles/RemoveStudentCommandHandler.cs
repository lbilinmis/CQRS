using CQRS.API.Data;
using CQRS.API.QueryCommand.Commands;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CQRS.API.QueryCommand.Handles
{
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand>
    {
        private readonly StudentContext _context;

        public RemoveStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }

        public void Handle(RemoveStudentCommand command)
        {
            var deletedStudent = _context.Students.Find(command.Id);
            _context.Students.Remove(deletedStudent);
            _context.SaveChanges();
        }

        public async Task<Unit> Handle(RemoveStudentCommand command, CancellationToken cancellationToken)
        {
            var deletedStudent = _context.Students.Find(command.Id);
            _context.Students.Remove(deletedStudent);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
