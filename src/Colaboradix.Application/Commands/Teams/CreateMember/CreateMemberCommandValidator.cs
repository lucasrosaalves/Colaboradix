using FluentValidation;

namespace Colaboradix.Application.Commands.Teams.CreateMember
{
    public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
    {
        public CreateMemberCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name must be informed");

            RuleFor(c => c.Email)
                .EmailAddress()
                .WithMessage("Email must be informed")
                .EmailAddress()
                .WithMessage("Email must be informed");

            RuleFor(c => c.TeamId)
                .NotEmpty()
                .WithMessage("TeamId must be informed");
        }
    }
}
