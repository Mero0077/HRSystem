using FluentValidation;
using HRSystem.Common.Constants;

namespace HRSystem.Features.Branch.Create_Branch
{

    public record CreateBranchRequestViewModel(string Name,string Description,string Location);
    public class CreateBranchRequestViewModelValidator : AbstractValidator<CreateBranchRequestViewModel>
    {
        public CreateBranchRequestViewModelValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(Constants.BranchNameNotEmptyValidator)
            .MaximumLength(50).WithMessage(Constants.BranchNameMaximumLengthValidator);

            RuleFor(x => x.Description).NotEmpty().WithMessage(Constants.BranchDescriptionNotEmptyValidator)
                .MaximumLength(150).WithMessage(Constants.BranchDescriptionMaximumLengthValidator);


            RuleFor(x => x.Location).NotEmpty().WithMessage(Constants.BranchLocationNotEmptyValidator)
                .MaximumLength(100).WithMessage(Constants.BranchLocationMaximumLengthValidator);
        }
    }
}
