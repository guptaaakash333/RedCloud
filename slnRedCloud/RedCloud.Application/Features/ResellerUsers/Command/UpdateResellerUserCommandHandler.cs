using AutoMapper;
using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Contracts.Persistence;
using RedCloud.Application.Features.OrganizationAdmins.Commands;
using RedCloud.Application.Features.RedCloudAdmins.Commands.CreateRedCloudAdmin;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.ResellerUsers.Command
{
    public class UpdateResellerUserCommandHandler : IRequestHandler<UpdateResellerUserCommand, Response<Unit>>
    {

        private readonly IAsyncRepository<ResellerUser> _repository;
        private readonly IMapper _mapper;


        public UpdateResellerUserCommandHandler(IAsyncRepository<ResellerUser> repository,IMapper mapper)
        {
            _mapper = mapper;   
            _repository = repository;
        }

        public async Task<Response<Unit>> Handle(UpdateResellerUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var ReselleruserObj = await _repository.GetByIdAsync(request.ResellerUserId);

                // Update properties of the existing entity
                _mapper.Map(request, ReselleruserObj);

                ReselleruserObj.LastModifiedDate = DateTime.Now;
                ReselleruserObj.LastModifiedBy = null;
                // The Password is already set in userObj, no need to reassign

                await _repository.UpdateAsync(ReselleruserObj);

                var response = new Response<Unit>("Updated Successfully");
                return response;
            }
            catch (Exception )
            {

                throw;
            }
        }


    }
}
