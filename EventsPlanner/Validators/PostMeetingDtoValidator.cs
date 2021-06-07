using EventsPlanner.Dto;
using FluentValidation;

namespace EventsPlanner.Validators
{
    public class PostMeetingDtoValidator : AbstractValidator<PostMeetingDto>
    {
        public PostMeetingDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Description)
                .Length(0, 100);
        }
    }
}
