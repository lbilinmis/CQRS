using CQRS.API.Data;
using CQRS.API.QueryCommand.Commands;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CQRS.API.QueryCommand.Handles
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly StudentContext _context;

        public UpdateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }

        public void Handle(UpdateStudentCommand command)
        {
            var updatedStudent = _context.Students.Find(command.Id);
            updatedStudent.Age = command.Age;
            updatedStudent.Name = command.Name;
            updatedStudent.Surname = command.Surname;
            _context.SaveChanges();
        }

        public async Task<Unit> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
        {
            var updatedStudent = _context.Students.Find(command.Id);
            updatedStudent.Age = command.Age;
            updatedStudent.Name = command.Name;
            updatedStudent.Surname = command.Surname;
            await _context.SaveChangesAsync();
            
            return Unit.Value;
        }
    }
}
