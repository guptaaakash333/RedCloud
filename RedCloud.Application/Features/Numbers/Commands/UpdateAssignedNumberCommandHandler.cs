using AutoMapper;
using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.Numbers.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Numbers.Commands
{
    public class UpdateAssignednumberCommandHandler : IRequestHandler<UpdateAssignedNumberCommand, Response<Unit>>
    {

        private readonly IAsyncRepository<Number> _repository;
        private readonly IMapper _mapper;


        public UpdateAssignednumberCommandHandler(IAsyncRepository<Number> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        public async Task<Response<Unit>> Handle(UpdateAssignedNumberCommand request, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(request.NumberId);
            model.NumberId = request.NumberId;
            //model.PhoneNumber = request.PhoneNumber;
            model.OrganizationAdminID = request.OrgID;
            model.ResellerAdminUserId = request.ResellerAdminUserId;
            model.AssignmentTypeId = request.AssignmentTypeId;
            model.CampaignId = request.CampaignId;
            model.StartDate = request.StartDate;
            model.EndDate = request.EndDate;
           // model.AssignmentTypeId = request.AssignmentTypeId;
           // model.StateId = request.StateId;
            //model.RateCenter = request.RateCenter;
            //model.CountryId = request.CountryId;
            //model.TypesId = request.TypeId;
            //model.LATA = request.LATA;
            //model.CarrierId = request.CarrierId;
            //model.State=request.StateName;
            await _repository.UpdateAsync(model);

            var response = new Response<Unit>("Updated Successfully");
            return response;
        }
    }

}
