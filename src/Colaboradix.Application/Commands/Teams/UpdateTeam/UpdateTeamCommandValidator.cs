using FluentValidation;

namespace Colaboradix.Application.Commands.Teams.UpdateTeam
{
    public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
    {
        public UpdateTeamCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id must be informed");

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name must be informed");
        }
    }
}
