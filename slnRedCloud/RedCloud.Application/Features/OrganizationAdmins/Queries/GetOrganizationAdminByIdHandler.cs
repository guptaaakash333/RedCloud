using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationAdmins.Queries
{
    public class GetOrganizationAdminByIdHandler : IRequestHandler<GetOrganizationAdminDetailsQuery, Response<OrganizationAdminDetailsVM>>
    {
        private readonly IAsyncRepository<OrganizationAdmin> _asyncRepository;
        private readonly IAsyncRepository<OrganizationResellerMapping> _asyncRepositoryMapping;

        public GetOrganizationAdminByIdHandler(IAsyncRepository<OrganizationAdmin> asyncRepository, IAsyncRepository<OrganizationResellerMapping> asyncRepositoryMapping)
        {
            _asyncRepository = asyncRepository;
            _asyncRepositoryMapping = asyncRepositoryMapping;
        }

        public async Task<Response<OrganizationAdminDetailsVM>> Handle(GetOrganizationAdminDetailsQuery request, CancellationToken cancellationToken)
        {
            var admin = await _asyncRepository.GetByIdAsyncInculde(request.Id);

            if (admin == null)
            {
                return new Response<OrganizationAdminDetailsVM>("Organization Admin not found");
            }
            var reseller = (await _asyncRepositoryMapping.ListAllAsync()).FirstOrDefault(x => x.OrganizationAdminId == request.Id);
            var model = new OrganizationAdminDetailsVM()
            {
                OrgID = admin.OrgID,
                OrgName = admin.OrgName,
                OrgAdminName = admin.OrgAdminName,
                OrgAdminEmail = admin.OrgAdminEmail,
                OrgAdminMobNo = admin.OrgAdminMobNo,
                AddressLineTwo = admin.AddressLineOne,
                AddressLineOne = admin.AddressLineTwo,
                CountryName = admin.Country.Name,
                StateName = admin.State.Name,
                CityName = admin.City.Name,
                ZipCode = admin.ZipCode,
                EIN = admin.EIN,
                CompanyURL = admin.OrgURL,
                IsActive = admin.IsActive,
                ResellerId = reseller.ResellerAdminUserId,
                OrgAdminPassword = admin.OrgAdminPassword,
            };

            return new Response<OrganizationAdminDetailsVM>(model);
        }
    }
}
