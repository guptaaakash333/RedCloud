using AutoMapper;
using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.OrganizationAdmins.Commands;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Numbers.Commands
{
    public class AddNumberCommandHandler : IRequestHandler<AddNumberCommand, Response<int>>
    {
        private readonly IAsyncRepository<Number> _asyncRepository;
        private readonly IMapper _mapper;

        public AddNumberCommandHandler(IAsyncRepository<Number> asyncRepository,IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;

        }
        public async Task<Response<int>> Handle(AddNumberCommand request, CancellationToken cancellationToken)
        {
           var number=_mapper.Map<Number>(request);
            number.CreatedBy = 1;
            number.CreatedDate = DateTime.Now;
            number.IsDeleted=false;
            number.IsActive=true;
            var result=await _asyncRepository.AddAsync(number);
            var response=new Response<int>(result.NumberId,"Inserted successfully");
            return response;
        }
    }
}
