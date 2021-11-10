using Application.Features.Persons.Commands;
using FluentValidation;
namespace Application.Validations
{
    /// <summary>
    /// Validator for Add Person CQRS
    /// </summary>
    public class AddPersonCommandValidation : AbstractValidator<AddPersonCommand>
    {
        public AddPersonCommandValidation()
        {
            RuleFor(request => request.FirstName)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("First Name is required!");
            RuleFor(request => request.LastName)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("Last Name is required!");
        }
    }
}
