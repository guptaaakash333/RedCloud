using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.OrganizationAdmins.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.ResellerUsers.Queries
{
    public class GetResellerUserDetailsByIdQueryHandler:IRequestHandler<GetResellerUserDetailsByIdQuery,Response<ResellerUserVM>>
    {
        private readonly IAsyncRepository<ResellerUser> _asyncRepository;

        public GetResellerUserDetailsByIdQueryHandler(IAsyncRepository<ResellerUser> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task<Response<ResellerUserVM>> Handle(GetResellerUserDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var admin = await _asyncRepository.GetByIdAsyncInculde(request.Id);

            if (admin == null)
            {
                return new Response<ResellerUserVM>("Organization Admin not found");
            }

            var model = new ResellerUserVM()
            {
                ResellerUserId = admin.ResellerUserId,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Email = admin.Email,
                ResellerAdminUserId = admin.ResellerAdminUserId,
                //AddressLineTwo = admin.AddressLineOne,
                //AddressLineOne = admin.AddressLineTwo,
                //CountryName = admin.Country.Name,
                //StateName = admin.State.Name,
                //CityName = admin.City.Name,
                //ZipCode = admin.ZipCode,
                //EIN = admin.EIN,
                //CompanyURL = admin.OrgURL,
                IsActive = admin.IsActive
            };

            return new Response<ResellerUserVM>(model);
        }

    }


}
