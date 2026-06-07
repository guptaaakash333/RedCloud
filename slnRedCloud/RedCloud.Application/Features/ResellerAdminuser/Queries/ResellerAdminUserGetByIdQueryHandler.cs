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

namespace RedCloud.Application.Features.ResellerAdminuser.Queries
{
    public class ResellerAdminUserGetByIdQueryHandler : IRequestHandler<ResellerAdminUserGetByIdQuery, Response<ResellerAdminUserVM>>
    {
        private readonly IAsyncRepository<ResellerAdminUser> _asyncRepository;
        private readonly IMapper _mapper;


        public ResellerAdminUserGetByIdQueryHandler(IAsyncRepository<ResellerAdminUser> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<Response<ResellerAdminUserVM>> Handle(ResellerAdminUserGetByIdQuery request, CancellationToken cancellationToken)
        {

            var admin = await _asyncRepository.GetByIdAsync(request.Id);

            if (admin == null)
            {
                return null;
            }

            var dto = new ResellerAdminUserVM()
            {
                ResellerAdminUserId = admin.ResellerAdminUserId,
                ResellerName = admin.ResellerName,
                EIN = admin.EIN,
                AddressLine1 = admin.AddressLine1,
                AddressLine2 = admin.AddressLine2,
                
                CityId = admin.CityId,
                StateId = admin.StateId,
                CountryId = admin.CountryId,
                ZipCode = admin.ZipCode,
                CompanyURL = admin.CompanyURL,
                CompanySupportEmail = admin.CompanySupportEmail,
                RedCloudAdmin = admin.RedCloudAdmin,
                Password = admin.Password

            };

            return new Response<ResellerAdminUserVM>(dto, "Successful"); ;


        }

    }
}
