using FluentValidation;

namespace Colaboradix.Application.UseCases.Commands.CreateUser
{
    internal class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name must be informed");

            RuleFor(c => c.Email)
                .EmailAddress()
                .WithMessage("Email must be informed");

            const string projectOrTeamError = "Project or Team must be informed";

            RuleFor(c => c.ProjectId)
                .NotEmpty()
                .When(c => !c.TeamId.HasValue)
                .WithMessage(projectOrTeamError);

            RuleFor(c => c.TeamId)
                .NotEmpty()
                .When(c => !c.ProjectId.HasValue)
                .WithMessage(projectOrTeamError);
        }
    }
}
