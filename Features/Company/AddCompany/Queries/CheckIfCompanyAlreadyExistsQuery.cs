using HRSystem.Common;
using HRSystem.Common.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Features.Company.AddCompany.Queries
{
    public record CheckIfCompanyAlreadyExistsQuery(string Name) : IRequest<RequestResult<bool>>;

    public class CheckIfCompanyAlreadyExistsQueryHandler : RequestHandlerBase<CheckIfCompanyAlreadyExistsQuery, bool>
    {
        private IGeneralRepository<HRSystem.Models.Company> _CompanyRepository;
        public CheckIfCompanyAlreadyExistsQueryHandler(IGeneralRepository<HRSystem.Models.Company> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _CompanyRepository = generalRepository;
        }

        public override async Task<RequestResult<bool>> Handle(CheckIfCompanyAlreadyExistsQuery request, CancellationToken cancellationToken)
        {
            var res = await _CompanyRepository.Get(e => e.Name == request.Name).FirstOrDefaultAsync();
            return res == null ? RequestResult<bool>.Failure("does not exist") : RequestResult<bool>.Success(true);
        }

      
    }
}
