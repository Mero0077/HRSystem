using HRSystem.Common;
using HRSystem.Common.Views;
using MediatR;

namespace HRSystem.Features.Company.AddCompany.Queries
{
    //public record CheckIfCompanyAlreadyExistsQuery(string Name):IRequest<RequestResult<bool>>;
    public record CheckIfCompanyAlreadyExistsQuery(string Name) : IRequest<bool>;
    //public class CheckIfCompanyAlreadyExistsQueryHandler : RequestHandlerBase<CheckIfCompanyAlreadyExistsQuery, bool>
    public class CheckIfCompanyAlreadyExistsQueryHandler : IRequestHandler<CheckIfCompanyAlreadyExistsQuery, bool>
    {
        //private IGeneralRepository<HRSystem.Models.Company> _CompanyRepository;
        //public CheckIfCompanyAlreadyExistsQueryHandler(IGeneralRepository<HRSystem.Models.Company> generalRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        //{
        //    _CompanyRepository = generalRepository;
        //}

        //public override async Task<RequestResult<bool>> Handle(CheckIfCompanyAlreadyExistsQuery request, CancellationToken cancellationToken)
        //{
        //    var res= await _CompanyRepository.GetOneWithTrackingAsync(e=>e.Name==request.Name);
        //    return res==null? RequestResult<bool>.Failure(false) : RequestResult<bool>.Success(true);
        //}

        private readonly IGeneralRepository<HRSystem.Models.Company> _companyRepository;

        public CheckIfCompanyAlreadyExistsQueryHandler(IGeneralRepository<HRSystem.Models.Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<bool> Handle(CheckIfCompanyAlreadyExistsQuery request, CancellationToken cancellationToken)
        {
            var exists = await _companyRepository.GetOneWithTrackingAsync(e => e.Name == request.Name);
            return exists != null;
        }
    }
}
