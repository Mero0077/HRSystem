using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.EndPoints.GetEndPoint.DTO;
using HRSystem.Models;
using MediatR;

namespace HRSystem.Features.EndPoints.GetEndPoint.Query
{
    public record GetEndPointQuery(EndPointDTO EndPointDTO) : IRequest<RequestResult<EndPointResponseVM>>;
    public class GetEndPointQueryHandler : RequestHandlerBase<GetEndPointQuery, EndPointResponseVM>
    {
        private IGeneralRepository<EndPointAction> _actionRepository;
        public GetEndPointQueryHandler(IGeneralRepository<EndPointAction> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _actionRepository = generalRepository;
        }

        public override async Task<RequestResult<EndPointResponseVM>> Handle(GetEndPointQuery request, CancellationToken cancellationToken)
        {
            var res = await _actionRepository.GetOneWithTrackingAsync(e => e.Path == request.EndPointDTO.Path && e.HttpMethod==request.EndPointDTO.Method);
            return res != null ?
                        RequestResult<EndPointResponseVM>.Success(mapper.Map<EndPointResponseVM>(res)) :
                        RequestResult<EndPointResponseVM>.Failure("No endpoint found!");
        }
    }
}
