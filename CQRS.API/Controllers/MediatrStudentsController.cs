using CQRS.API.QueryCommand.Commands;
using CQRS.API.QueryCommand.Handles;
using CQRS.API.QueryCommand.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediatrStudentsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public MediatrStudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(id));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetStudentsQuery());

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
            var result = await _mediator.Send(command);


            return Created("", command.Name);
        }


        [HttpPut]
        public async Task<IActionResult> Update(CreateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("id")]
        public async Task<IActionResult> Remove(int id)
        {
            var result= await _mediator.Send(new RemoveStudentCommand(id));

            return NoContent();
        }

    }
}
