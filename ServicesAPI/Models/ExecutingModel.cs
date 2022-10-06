using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MediatR;


namespace SuperHeroAPI.Models
{
    public class ExecutingModel
    {
        private readonly IMediator _mediatr;

        public ExecutingModel(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        public async Task<IActionResult> ValidateAndRequest<T>(IValidator<T> validator, T command)
        {
            ValidationResult validating = validator.Validate(command);
            if (!validating.IsValid)
            {
                var modelStateDicitornary = new ModelStateDictionary();
                foreach (ValidationFailure failure in validating.Errors)
                {
                    modelStateDicitornary.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                BadRequestObjectResult errors = new BadRequestObjectResult(modelStateDicitornary);
                return await Task.FromResult(errors);
            }
            OkObjectResult result = new OkObjectResult(await _mediatr.Send(command));
            return await Task.FromResult(result);
        }
    }
}
