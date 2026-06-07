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

namespace RedCloud.Application.Features.RedCloudAdmins.Commands.CreateRedCloudAdmin
{
    public class EditRedCloudAdminCommandHandler : IRequestHandler<EditRedCloudAdminCommand, Response<Unit>>
    {
        private readonly IAsyncRepository<RedCloudAdmin> _repository;
        private readonly IMapper _mapper;
        public EditRedCloudAdminCommandHandler(IAsyncRepository<RedCloudAdmin> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
       
        public async Task<Response<Unit>> Handle(EditRedCloudAdminCommand request, CancellationToken cancellationToken)
        {
            var userObj = await _repository.GetByIdAsync(request.RedCloudAdminUserId);

            // Update properties of the existing entity
            _mapper.Map(request, userObj);

            userObj.LastModifiedDate = DateTime.UtcNow;
            userObj.LastModifiedBy = null;
            // The Password is already set in userObj, no need to reassign

            await _repository.UpdateAsync(userObj);

            var response = new Response<Unit>("Updated Successfully");
            return response;
        }
    }
}
