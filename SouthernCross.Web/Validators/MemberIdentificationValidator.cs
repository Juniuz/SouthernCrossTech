using FluentValidation;
using SouthernCross.Web.Dto;

namespace SouthernCross.Web.Validators
{
    public class MemberIdentificationValidator : AbstractValidator<MemberIdentification>
    {
        public MemberIdentificationValidator()
        {
            RuleFor(m => m.PolicyNumber).Must(m => int.TryParse(m.ToString(), out int policyNumber)).WithMessage("Policy number should be a number");
            RuleFor(m => m.PolicyNumber).Must(m => m.ToString().Length == 10).WithMessage("Policy number should be 10 digits");

            RuleFor(m => m.CardNumber).Must(m => int.TryParse(m.ToString(), out int cardNumber)).WithMessage("Card number should be a number");
            RuleFor(m => m.CardNumber).Must(m => m.ToString().Length == 10).WithMessage("Card number should be 10 digits");

            RuleFor(m => m.PolicyNumber)
                .NotEmpty()
                .When(m => m.CardNumber > 0)
                .WithMessage("Policy number or Member card number are required (one of both, or both)");
        }
    }
}
