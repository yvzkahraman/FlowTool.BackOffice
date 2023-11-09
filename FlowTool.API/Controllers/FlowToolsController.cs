using FlowTool.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlowTool.API.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class FlowToolsController : ControllerBase
    {
        private readonly IMediator mediator;

        public FlowToolsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectRequest request)
        {
            var result = await this.mediator.Send(request);
            return Created("", result.Data);
        }


        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await this.mediator.Send(new GetListProjectRequest());
            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.mediator.Send(new GetProjectByIdRequest(id));

            return Ok(result.Data);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProjectRequest request)
        {
            var result = await this.mediator.Send(request);
            return NoContent();
        }
    }
}
