using AutoMapper;
using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.OrganizationUsers.Commands;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationUsers.Commands
{
    public class CreateOrganizationUserCommandHandler : IRequestHandler<CreateOrganizationUserCommand, Response<int>>
    {
        private readonly IAsyncRepository<OrganizationUser> _repository;
        private readonly IMapper _mapper;

        public CreateOrganizationUserCommandHandler(IAsyncRepository<OrganizationUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateOrganizationUserCommand request, CancellationToken cancellationToken)
        {         
            //request.Password = GenerateRandomPassword();
                  // var encryptedPassword = EncryptionDecryption.EncryptString(request.Password);

            var organizationUser = _mapper.Map<OrganizationUser>(request);
            //  adminuser.Password = encryptedPassword;

            organizationUser.IsDeleted = false;
            organizationUser.CreatedDate = DateTime.UtcNow;
            organizationUser.CreatedBy = null;
            organizationUser.IsActive = true;



            var result = await _repository.AddAsync(organizationUser);
            var response = new Response<int>(result.OrganizationUserId, "Inserted successfully");
            return response;
        }
    }
}
