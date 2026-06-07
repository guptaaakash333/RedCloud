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

namespace RedCloud.Application.Features.RedCloudAdmins.Queries
{
    public class GetRedCloudAdminByIdQueryHandler : IRequestHandler <GetRedCloudAdminByIdQuery, Response<RedCloudAdmin>> { 

        private readonly IAsyncRepository<RedCloudAdmin> _repository;
        private readonly IMapper _mapper;

        public GetRedCloudAdminByIdQueryHandler(IAsyncRepository<RedCloudAdmin> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<RedCloudAdmin>> Handle(GetRedCloudAdminByIdQuery request, CancellationToken cancellationToken)
        {
            var adminUser = await _repository.GetByIdAsync(request.RedCloudAdminUserId);
            return new Response<RedCloudAdmin>(adminUser, "success");
        }


    }
}
