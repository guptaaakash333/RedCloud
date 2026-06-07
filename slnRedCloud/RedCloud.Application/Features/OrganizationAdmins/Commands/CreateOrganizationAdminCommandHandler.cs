using AutoMapper;
using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Helper;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationAdmins.Commands
{
    public class CreateOrganizationAdminCommandHandler : IRequestHandler<CreateOrganizationAdminCommand, Response<int>>
    {
        private readonly IAsyncRepository<OrganizationAdmin> _asyncRepository;
        private readonly IAsyncRepository<OrganizationResellerMapping> _asyncRepositoryMapping;

        private readonly IMapper _mapper;
 




        public CreateOrganizationAdminCommandHandler(IAsyncRepository<OrganizationAdmin> asyncRepository, IMapper mapper,
            IAsyncRepository<OrganizationResellerMapping> asyncRepositoryMapping)
        {
            _asyncRepository = asyncRepository;
            _asyncRepositoryMapping = asyncRepositoryMapping;
            _mapper = mapper;
           
        }

        private string GenerateRandomPassword()
        {
            const int passwordLength = 12;
            const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";

            var random = new Random();
            return new string(Enumerable.Repeat(allowedChars, passwordLength)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task<Response<int>> Handle(CreateOrganizationAdminCommand request, CancellationToken cancellationToken)
        {
            request.OrgAdminPassword = GenerateRandomPassword();
            
         
            var encryptedPassword = EncryptionDecryption.EncryptString(request.OrgAdminPassword);

            var org = _mapper.Map<OrganizationAdmin>(request);
            org.OrgAdminPassword = encryptedPassword;

            //var org = _mapper.Map<OrganizationAdmin>(request);
          
            org.CreatedBy = 1;
            org.CreatedDate = DateTime.Now;
            org.IsDeleted = false;
            org.IsActive = true;
            var result = await _asyncRepository.AddAsync(org);
            var mapping = new OrganizationResellerMapping()
            {
                OrganizationAdminId = result.OrgID,
                ResellerAdminUserId = request.ResellerId
            };
            var map = await _asyncRepositoryMapping.AddAsync(mapping);
            var response = new Response<int>(result.OrgID, "Inserted successfully ");
            return response;
        }
    }
}
