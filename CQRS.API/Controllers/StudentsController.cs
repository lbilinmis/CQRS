using CQRS.API.QueryCommand.Commands;
using CQRS.API.QueryCommand.Handles;
using CQRS.API.QueryCommand.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly GetStudentByIdQueryHandler _getStudentByIdQueryHandler;
        private readonly GetStudentsQueryHandler _getStudentsQueryHandler;
        private readonly CreateStudentCommandHandler _createStudentCommandHandler;
        private readonly RemoveStudentCommandHandler _removeStudentCommandHandler;
        private readonly UpdateStudentCommandHandler    _updateStudentCommandHandler;
        public StudentsController(GetStudentByIdQueryHandler getStudentByIdQueryHandler, GetStudentsQueryHandler getStudentsQueryHandler, CreateStudentCommandHandler createStudentCommandHandler, RemoveStudentCommandHandler removeStudentCommandHandler, UpdateStudentCommandHandler updateStudentCommandHandler)
        {
            _getStudentByIdQueryHandler = getStudentByIdQueryHandler;
            _getStudentsQueryHandler = getStudentsQueryHandler;
            _createStudentCommandHandler = createStudentCommandHandler;
            _removeStudentCommandHandler = removeStudentCommandHandler;
            _updateStudentCommandHandler = updateStudentCommandHandler;
        }

        [HttpGet("id")]
        public IActionResult GetStudent(int id)
        {
            var result = _getStudentByIdQueryHandler.Handle(new GetStudentByIdQuery(id));

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var result = _getStudentsQueryHandler.Handle(new GetStudentsQuery());

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreateStudentCommand command)
        {
            _createStudentCommandHandler.Handle(command);

            return Created("",command.Name);
        }


        [HttpDelete("id")]
        public IActionResult Remove(int id)
        {
            _removeStudentCommandHandler.Handle(new RemoveStudentCommand(id));

            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(UpdateStudentCommand command)
        {
            _updateStudentCommandHandler.Handle(command);

            return NoContent();
        }


    }
}
