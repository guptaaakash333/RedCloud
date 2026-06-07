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

namespace RedCloud.Application.Features.OrganizationUsers.Commands
{
    public class UpdateOrganizationUserCommandHandler : IRequestHandler<UpdateOrganizationUserCommand, Response<Unit>>
    {
        private readonly IAsyncRepository<OrganizationUser> _repository;
        private readonly IMapper _mapper;


        public UpdateOrganizationUserCommandHandler(IAsyncRepository<OrganizationUser> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<Unit>> Handle(UpdateOrganizationUserCommand request, CancellationToken cancellationToken)
        {
            var updateOrganizationUser = await _repository.GetByIdAsync(request.OrganizationUserId);

            // Update properties of the existing entity
            _mapper.Map(request, updateOrganizationUser);
            updateOrganizationUser.IsActive = request.IsActive;
            updateOrganizationUser.LastModifiedDate = DateTime.Now;
            updateOrganizationUser.LastModifiedBy = null;
            // The Password is already set in userObj, no need to reassign

            await _repository.UpdateAsync(updateOrganizationUser);

            var response = new Response<Unit>("Updated Successfully");
            return response;
        }

     
    }
}

