using FluentValidation;

namespace Colaboradix.Application.UseCases.Queries.GetUsersByTeamOrProject
{
    internal class GetUsersByTeamOrProjectQueryValidator : AbstractValidator<GetUsersByProjectOrTeamQuery>
    {
        public GetUsersByTeamOrProjectQueryValidator()
        {
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
