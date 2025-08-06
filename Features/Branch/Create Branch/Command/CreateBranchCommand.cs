using HRSystem.Common;
using HRSystem.Common.Views;
using MediatR;

namespace HRSystem.Features.Branch.Create_Branch.Command
{

    public record CreateBranchCommand : IRequest<RequestResult<bool>>;
    public class CreateBranchCommandHandler : RequestHandlerBase<CreateBranchCommand, bool>
    {
        public CreateBranchCommandHandler(RequestHandlerBaseParameters parameters) : base(parameters)
        {

        }

        public override Task<RequestResult<bool>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
