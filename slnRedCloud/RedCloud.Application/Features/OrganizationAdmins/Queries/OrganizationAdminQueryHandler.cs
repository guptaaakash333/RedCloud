using AutoMapper;
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
    public class OrganizationAdminQueryHandler : IRequestHandler<OrganizationAdminQuery, Response<OrganizationAdminVM>>
    {
        private readonly IAsyncRepository<OrganizationAdmin> _asyncRepository;
        private readonly IAsyncRepository<OrganizationResellerMapping> _asyncRepositoryMapping;

        private readonly IMapper _mapper;


        public OrganizationAdminQueryHandler(IAsyncRepository<OrganizationAdmin> asyncRepository, IMapper mapper, IAsyncRepository<OrganizationResellerMapping> asyncRepositoryMapping)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _asyncRepositoryMapping = asyncRepositoryMapping;
        }



        public async Task<Response<OrganizationAdminVM>> Handle(OrganizationAdminQuery request, CancellationToken cancellationToken)
        {
            var admin = await _asyncRepository.GetByIdAsync(request.Id);
            var reseller = (await _asyncRepositoryMapping.ListAllAsync()).FirstOrDefault(x => x.OrganizationAdminId == request.Id);
            if (admin == null)
            {
                return null;
            }

            var dto = new OrganizationAdminVM()
            {
                OrgID = admin.OrgID,
                OrgName = admin.OrgName,
                OrgAdminName = admin.OrgAdminName,
                OrgAdminEmail = admin.OrgAdminEmail,
                EIN = admin.EIN,
                OrgAdminPassword = admin.OrgAdminPassword,
                CountryId = admin.CountryId,
                CityId = admin.CityId,
                StateId = admin.StateId,
                ZipCode = admin.ZipCode,
                OrgAdminMobNo = admin.OrgAdminMobNo,
                AddressLineOne = admin.AddressLineOne,
                AddressLineTwo = admin.AddressLineTwo,
                OrgURL = admin.OrgURL,
                ResellerId = reseller.ResellerAdminUserId,

            };

            return new Response<OrganizationAdminVM>(dto, "Successful");
        }
    }
}
