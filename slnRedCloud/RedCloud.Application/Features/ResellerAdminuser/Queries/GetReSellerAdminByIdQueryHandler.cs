using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.ResellerAdminuser.Queries
{
    public class GetReSellerAdminByIdQueryHandler : IRequestHandler<GetReSellerAdminByIdQuery, Response<ReSellerAdmindto>>
    {
        private readonly IAsyncRepository<ResellerAdminUser> _asyncRepository;

        public GetReSellerAdminByIdQueryHandler(IAsyncRepository<ResellerAdminUser> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task<Response<ReSellerAdmindto>> Handle(GetReSellerAdminByIdQuery request, CancellationToken cancellationToken)
        {
            var admin = await _asyncRepository.GetByIdAsyncInculde(request.Id);

            if (admin == null)
            {
                return new Response<ReSellerAdmindto>("Reseller Admin not found");
            }

            var model = new ReSellerAdmindto()
            {
                ResellerAdminUserId = admin.ResellerAdminUserId, 
                ResellerName = admin.ResellerName,
                EIN = admin.EIN,
                AddressLine1 = admin.AddressLine1,
                AddressLine2 = admin.AddressLine2,
                ZipCode = admin.ZipCode,
                CompanyURL = admin.CompanyURL,
                CompanySupportEmail = admin.CompanySupportEmail,
                RedCloudAdmin = admin.RedCloudAdmin,
                CountryName = admin.Country.Name,
                StateName = admin.State.Name,
                CityName = admin.City.Name,
                Password=admin.Password,
                
            };


            return new Response<ReSellerAdmindto>(model, "Success");
        }
    }
}
