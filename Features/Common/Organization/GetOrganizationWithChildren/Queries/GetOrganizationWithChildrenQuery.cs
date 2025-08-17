using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Common.Organization.GetOrganizationWithChildren.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Features.Common.Organization.GetOrganizationWithChildren.Queries
{
    public record GetOrganizationWithChildrenQuery(GetOrganizationWithChildrenRequestDTO GetOrganizationWithChildrenRequestDTO) : IRequest<RequestResult<GetOrganizationWithChildrenResponseDTO>>;

    public class GetOrganizationWithChildrenQueryHandler : RequestHandlerBase<GetOrganizationWithChildrenQuery, GetOrganizationWithChildrenResponseDTO>
    {
        private readonly IGeneralRepository<Models.Organization> _organicationRepository;

        public GetOrganizationWithChildrenQueryHandler(IGeneralRepository<Models.Organization> organicationRepository ,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._organicationRepository = organicationRepository;
        }

        public override async Task<RequestResult<GetOrganizationWithChildrenResponseDTO>> Handle(GetOrganizationWithChildrenQuery request, CancellationToken cancellationToken)
        {
            var result = await _organicationRepository.Get(
                e => e.Id == request.GetOrganizationWithChildrenRequestDTO.OrganizationId)
                .Include(e => e.companies.Where(e=>!e.IsDeleted)).FirstOrDefaultAsync(cancellationToken);
            if (result == null)
                return RequestResult<GetOrganizationWithChildrenResponseDTO>.Failure("Organization Not Found",ErrorCodes.NotFound);

            var responseDTO = mapper.Map<GetOrganizationWithChildrenResponseDTO>(result);
            return RequestResult<GetOrganizationWithChildrenResponseDTO>.Success(responseDTO);
        }
    }
}
