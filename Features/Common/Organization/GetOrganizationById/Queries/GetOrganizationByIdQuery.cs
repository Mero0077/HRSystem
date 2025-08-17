using AutoMapper.QueryableExtensions;
using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Common.Organization.GetOrganizationById.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Features.Common.Organization.GetOrganizationById.Queries
{

    public record GetOrganizationByIdQuery(GetOrganizationByIdRequestDTO getOrganizationByIdRequestDTO) : IRequest<RequestResult<GetOrganizationByIdResponseDTO>>;
    public class GetOrganizationByIdQueryHandler : RequestHandlerBase<GetOrganizationByIdQuery, GetOrganizationByIdResponseDTO>
    {
        private readonly IGeneralRepository<Models.Organization> _organizationRepository;

        public GetOrganizationByIdQueryHandler(IGeneralRepository<Models.Organization> organizationRepository ,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._organizationRepository = organizationRepository;
        }

        public override async Task<RequestResult<GetOrganizationByIdResponseDTO>> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _organizationRepository
                .Get(e => e.Id == request.getOrganizationByIdRequestDTO.OrganizationId)
                .ProjectTo<GetOrganizationByIdResponseDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken)
                ;
            if (result == null)
                return RequestResult<GetOrganizationByIdResponseDTO>.Failure("Organization is n't found",ErrorCodes.NotFound);

            return RequestResult<GetOrganizationByIdResponseDTO>.Success(result);

        }
    }
}
