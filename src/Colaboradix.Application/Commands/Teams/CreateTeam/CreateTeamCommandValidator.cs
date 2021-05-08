using FluentValidation;

namespace Colaboradix.Application.Commands.Teams.CreateTeam
{
    public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
    {
        public CreateTeamCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name must be informed");
        }
    }
}
