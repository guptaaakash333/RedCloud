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

namespace RedCloud.Application.Features.OrganizationAdmins.Commands
{
    public class UpdateOrganizationAdminCommandHandler : IRequestHandler<UpdateOrganizationAdminCommand, Response<Unit>>
    {

        private readonly IAsyncRepository<OrganizationAdmin> _repository;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<OrganizationResellerMapping> _asyncRepositoryMapping;



        public UpdateOrganizationAdminCommandHandler(IAsyncRepository<OrganizationAdmin> repository, IMapper mapper, IAsyncRepository<OrganizationResellerMapping> asyncRepositoryMapping)
        {
            _repository = repository;
            _mapper = mapper;
            _asyncRepositoryMapping = asyncRepositoryMapping;
        }

        private string GenerateRandomPassword()
        {
            const int passwordLength = 12;
            const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";

            var random = new Random();
            return new string(Enumerable.Repeat(allowedChars, passwordLength)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task<Response<Unit>> Handle(UpdateOrganizationAdminCommand request, CancellationToken cancellationToken)
        {

            var model = await _repository.GetByIdAsync(request.OrgID);
            var reseller = (await _asyncRepositoryMapping.ListAllAsync()).FirstOrDefault(x => x.OrganizationAdminId == request.OrgID);
            reseller.ResellerAdminUserId = request.ResellerId;
            request.OrgAdminPassword = model.OrgAdminPassword;
            model.IsActive = request.IsActive;
            _mapper.Map(request, model, typeof(UpdateOrganizationAdminCommand), typeof(OrganizationAdmin));

            model.LastModifiedBy = 1;
            model.LastModifiedDate = DateTime.Now;
            await _repository.UpdateAsync(model);

            await _asyncRepositoryMapping.UpdateAsync(reseller);
            var response = new Response<Unit>("Inserted successfully");
            return response;
        }

    }
}
