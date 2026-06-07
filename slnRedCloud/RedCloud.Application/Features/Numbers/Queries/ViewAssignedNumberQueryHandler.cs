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

namespace RedCloud.Application.Features.Numbers.Queries
{
    public  class ViewAssignedNumberQueryHandler : IRequestHandler<ViewAssignedNumberQuery, Response<ViewAssignedNumberVM>>
    {
        private readonly IAsyncRepository<Number> _asyncRepository;
        private readonly IMapper _mapper;


        public ViewAssignedNumberQueryHandler(IAsyncRepository<Number> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }






        public async Task<Response<ViewAssignedNumberVM>> Handle(ViewAssignedNumberQuery request, CancellationToken cancellationToken)
        {
            var number = await _asyncRepository.GetByIdAsyncInculde(request.Id);

            if (number == null)
            {
                return null;
            }

            var dto = new ViewAssignedNumberVM()
            {

                NumberId = number.NumberId,
                CountryName = number.Country.Name,
                PhoneNumber = number.PhoneNumber,
                TypeName = number.Types.TypesName,
                LATA = number.LATA,
                ResellerName = number.ResellerAdminUsers.ResellerName,
                OrgID=number.OrganizationAdmin.OrgID,
                OrgName = number.OrganizationAdmin.OrgName,
                AssignmentTypeName = number.AssignmentType.AssignmentTypeName,
                CarrierName = number.Carrier.CarrierName,
                RateCenter = number.RateCenter,
                StateName = number.State.Name,
                CampaignId = number.CampaignId,
                StartDate = number.StartDate,
                EndDate = number.EndDate,
                Status=number.Status,

            };

            return new Response<ViewAssignedNumberVM>(dto, "Successful");
        }

    }


}
