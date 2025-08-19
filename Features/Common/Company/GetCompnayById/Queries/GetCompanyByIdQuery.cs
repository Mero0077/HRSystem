using AutoMapper.QueryableExtensions;
using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Common.Company.GetCompnayByIdQuery.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Features.Common.Company.GetCompnayByIdQuery.Queries
{
    public record GetCompanyByIdQuery(GetCompanyByIdQueryRequestDTO GetCompanyByIdQueryRequest) : IRequest<RequestResult<GetCompanyByIdQueryResponseDTO>>;
    public class GetCompanyByIdQueryHandler : RequestHandlerBase<GetCompanyByIdQuery, GetCompanyByIdQueryResponseDTO>
    {
        private readonly IGeneralRepository<Models.Company> _companyRepository;

        public GetCompanyByIdQueryHandler(IGeneralRepository<Models.Company> companyRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._companyRepository = companyRepository;
        }

        public override async Task<RequestResult<GetCompanyByIdQueryResponseDTO>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            var userStateOrganizationId = userState.OrganizationId;

            request.GetCompanyByIdQueryRequest.OrganizationId = userStateOrganizationId;

            var company = await _companyRepository.
                 Get(e => e.Id == request.GetCompanyByIdQueryRequest.CompanyId, request.GetCompanyByIdQueryRequest.OrganizationId)
                .ProjectTo<GetCompanyByIdQueryResponseDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
                ;
            if (company == null)
                return RequestResult<GetCompanyByIdQueryResponseDTO>.Failure("Company is N't Found",ErrorCodes.NotFound);
            return RequestResult<GetCompanyByIdQueryResponseDTO>.Success(company);

        }
    }
}
