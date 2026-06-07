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

namespace RedCloud.Application.Features.OrganizationUsers.Queries
{
    public class GetOrganizationUserByIdQueryHandler : IRequestHandler<GetOrganizationUserByIdQuery, Response<GetAllOrganizationUserVM>>
    {
        private readonly IAsyncRepository<OrganizationUser> _asyncRepository;
        private readonly IAsyncRepository<OrganizationResellerMapping> _asyncRepositoryMapping;

        public GetOrganizationUserByIdQueryHandler(IAsyncRepository<OrganizationUser> asyncRepository, IAsyncRepository<OrganizationResellerMapping> asyncRepositoryMapping)
        {
            _asyncRepository = asyncRepository;
            _asyncRepositoryMapping = asyncRepositoryMapping;
        }

        public async Task<Response<GetAllOrganizationUserVM>> Handle(GetOrganizationUserByIdQuery request, CancellationToken cancellationToken)
        {
            var admin = await _asyncRepository.GetByIdAsyncInculde(request.Id);

            if (admin == null)
            {
                return new Response<GetAllOrganizationUserVM>("Organization Admin not found");
            }
            //var reseller = (await _asyncRepositoryMapping.ListAllAsync()).FirstOrDefault(x => x.OrganizationAdminId == request.Id);
            var model = new GetAllOrganizationUserVM()
            {
               OrganizationUserId = request.Id,
               OrganizationUserFirstName = admin.OrganizationUserFirstName,
               OrganizationUserLastName = admin.OrganizationUserLastName,
               OrganizationUserEmail = admin.OrganizationUserEmail,
               OrganizationAdminId = admin.OrganizationAdminId,
               IsActive = admin.IsActive,
               

            };

            return new Response<GetAllOrganizationUserVM>(model);
        }
    }
}
