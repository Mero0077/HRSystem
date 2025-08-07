using AutoMapper;
using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Company.AddCompany.DTOs;
using HRSystem.Features.Company.AddCompany.Queries;
using MediatR;

namespace HRSystem.Features.Company.AddCompany.Command
{
    public record AddCompanyCommand(AddCompanyDTO AddCompanyDTO):IRequest<RequestResult<AddCompanyResponseVM>>;
    public class AddCompanyCommandHandler : RequestHandlerBase<AddCompanyCommand,AddCompanyResponseVM>
    {
        private IGeneralRepository<HRSystem.Models.Company> _CompanyRepository;
        public AddCompanyCommandHandler(IGeneralRepository<HRSystem.Models.Company> generalRepository ,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _CompanyRepository = generalRepository;
        }

        public override async Task<RequestResult<AddCompanyResponseVM>> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
         var exists = await mediator.Send(new CheckIfCompanyAlreadyExistsQuery(request.AddCompanyDTO.Name));
            if (!exists.IsSuccess) return RequestResult<AddCompanyResponseVM>.Failure("already exists", ErrorCodes.AlreadyExists);

         var res= await _CompanyRepository.AddAsync(mapper.Map<HRSystem.Models.Company>(request.AddCompanyDTO));
                  await _CompanyRepository.SaveChangesAsync();
             return res!=null?
                RequestResult<AddCompanyResponseVM>.Success(mapper.Map<AddCompanyResponseVM>(res),"Company added"):
                RequestResult<AddCompanyResponseVM>.Failure("Could not add company",ErrorCodes.AlreadyExists);

        }
    }
}
