using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MediatR;
using SuperHeroAPI.Queries;
using SuperHeroAPI.Handlers;
using SuperHeroAPI.Commands;
using FluentValidation.Results;
using FluentValidation;
using ValidationResult = FluentValidation.Results.ValidationResult;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal;
using Microsoft.AspNetCore.Mvc.Filters;
using SuperHeroAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SuperHeroAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly IValidator<CreateSuperHeroCommand> _createvalidator;
        private readonly IValidator<UpDateSuperHeroCommand> _updatevalidator;

        public SuperHeroController(IMediator mediatr, IValidator<CreateSuperHeroCommand> createvalidator, IValidator<UpDateSuperHeroCommand> updatevalidator)
        {
            this._mediatr = mediatr;
            _createvalidator = createvalidator;
            _updatevalidator = updatevalidator;

        }

        [HttpGet]
        public async Task<IActionResult> GetSuperHeroes() => Ok(await _mediatr.Send(new GetSuperHeroListQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSuperHeroesByID(int id) => Ok(await _mediatr.Send(new GetSuperHerobyIdQuery(id)));

        [HttpPost]
        public async Task<IActionResult> CreateSuperHero(CreateSuperHeroCommand command)
        {
            ExecutingModel model = new ExecutingModel(_mediatr);
            return await model.ValidateAndRequest(_createvalidator, command);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHero(UpDateSuperHeroCommand updatehero)
        {
            ExecutingModel model = new ExecutingModel(_mediatr);
            return await model.ValidateAndRequest(_updatevalidator, updatehero);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            return Ok(await _mediatr.Send(new DeleteSuperHeroCommand(id)));
        }


    }
}
