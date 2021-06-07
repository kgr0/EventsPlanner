using EventsPlanner.Dto;
using FluentValidation;

namespace EventsPlanner.Validators
{
    public class PostUserDtoValidator : AbstractValidator<PostUserDto>
    {
        public PostUserDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Name)
                .NotEmpty(); 
        }
    }
}
