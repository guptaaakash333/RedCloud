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

namespace RedCloud.Application.Features.Numbers.Commands
{
    public  class AssignNumberCommandHandler:IRequestHandler<AssignNumberCommand, Response<Unit>>
    {
        private readonly IAsyncRepository<Number> _asyncRepository;
        private readonly IMapper _mapper;

    public AssignNumberCommandHandler(IAsyncRepository<Number> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;

    }
 
        public async Task<Response<Unit>> Handle(AssignNumberCommand request, CancellationToken cancellationToken)
        {

            var model = await _asyncRepository.GetByIdAsync(request.NumberId ?? 0);
            model.StartDate = request.StartDate;
            model.EndDate = request.EndDate;
            model.AssignmentTypeId = request.AssignmentTypeId;  
            model.ResellerAdminUserId = request.ResellerAdminUserId;    
            model.OrganizationAdminID = request.OrgID;                
            model.CampaignId = request.CampaignId;
           // model.Status = request.Status;
             await _asyncRepository.UpdateAsync(model);
            var response = new Response<Unit>( "Number Assigned successfully");
            return response;
            //

          
        }
    }
    
}
