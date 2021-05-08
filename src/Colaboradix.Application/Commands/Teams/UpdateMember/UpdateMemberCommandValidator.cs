using FluentValidation;

namespace Colaboradix.Application.Commands.Teams.UpdateMember
{
    public class UpdateMemberCommandValidator : AbstractValidator<UpdateMemberCommand>
    {
        public UpdateMemberCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Name must be informed");

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name must be informed");

            RuleFor(c => c.TypeId)
                .NotEmpty()
                .WithMessage("TypeId must be informed");

            RuleFor(c => c.TeamId)
                .NotEmpty()
                .WithMessage("TeamId must be informed");
        }
    }
}
