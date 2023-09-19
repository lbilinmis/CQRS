namespace CQRS.API.QueryCommand.Commands
{
    public class RemoveStudentCommand
    {
        public int Id { get; set; }

        public RemoveStudentCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
