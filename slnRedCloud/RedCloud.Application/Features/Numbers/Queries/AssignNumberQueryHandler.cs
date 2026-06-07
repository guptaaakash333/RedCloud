using AutoMapper;
using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.Numbers.Commands;
using RedCloud.Application.Features.OrganizationAdmins.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Numbers.Queries
{
    public class AssignNumberQueryHandler : IRequestHandler<AssignNumberQuery, Response<AssignNumberViewModel>>
    {
        private readonly IAsyncRepository<Number> _asyncRepository;
        private readonly IMapper _mapper;


        public AssignNumberQueryHandler(IAsyncRepository<Number> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<Response<AssignNumberViewModel>> Handle(AssignNumberQuery request, CancellationToken cancellationToken)
        {
            var number = await _asyncRepository.GetByIdAsyncInculde(request.NumberId);

            if (number == null)
            {
                return null;
            }

            var dto = new AssignNumberViewModel()
            {

                NumberId = number.NumberId,
                PhoneNumber = number.PhoneNumber,
                RateCenter = number.RateCenter,
                TypeName = number.Types.TypesName,
                CountryName = number.Country.Name,
                LATA = number.LATA,
                StateName = number.State.Name,
                CarrierName = number.Carrier.CarrierName,
                Status=number.Status,

            };

            return new Response<AssignNumberViewModel>(dto, "Successful");
        }
    }
}