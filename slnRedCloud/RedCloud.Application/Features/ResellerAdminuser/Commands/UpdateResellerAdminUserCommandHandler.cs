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

namespace RedCloud.Application.Features.ResellerAdminuser.Commands
{
    public  class UpdateResellerAdminUserCommandHandler: IRequestHandler<UpdateResellerAdminUserCommand, Response<Unit>>
    {

        private readonly IAsyncRepository<ResellerAdminUser> _repository;
        private readonly IMapper _mapper;


        public UpdateResellerAdminUserCommandHandler(IAsyncRepository<ResellerAdminUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<Unit>> Handle(UpdateResellerAdminUserCommand request, CancellationToken cancellationToken)
        {
            var adminuser = _mapper.Map<ResellerAdminUser>(request);
            adminuser.IsDeleted = false;
            adminuser.LastModifiedBy = 1;
            adminuser.LastModifiedDate = DateTime.Now;
            await _repository.UpdateAsync(adminuser);
            var response = new Response<Unit>("Inserted successfully");
            return response;
        }
    }
}

