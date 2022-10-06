using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesAPI.Application.Commands;
using ServicesAPI.Application.Profiles;
using ServicesAPI.Data;
using ServicesAPI.Models;
using ServicesAPI.Queries;
using SuperHeroAPI.Models;

namespace ServicesAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
       
        private readonly IMediator _mediator;
        private readonly IValidator<CreateServiceCommand> _createvalidator;
        private readonly IValidator<UpDateServiceCommand> _updatevalidator;

        public ServicesController( IMediator mediator)
        {
            
            this._mediator = mediator;
        }


        [HttpGet("AllServices")]
        public async Task<IActionResult> GetAll()
        {

           return  Ok(await _mediator.Send(new GetAllServiceListQuery()));
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyID(int id)
        {
            return Ok(await _mediator.Send(new GetServicebyIDQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            ExecutingModel model = new ExecutingModel(_mediator);
            return await model.ValidateAndRequest(_createvalidator, command);
        }

        [HttpPut]
        public async Task<IActionResult> UpDateService(UpDateServiceCommand command)
        {
            ExecutingModel model = new ExecutingModel(_mediator);
            return await model.ValidateAndRequest(_updatevalidator, command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByID(int id)
        {
            return Ok(await _mediator.Send(new DeleteServiceCommand(id)));
        }




    }
}
