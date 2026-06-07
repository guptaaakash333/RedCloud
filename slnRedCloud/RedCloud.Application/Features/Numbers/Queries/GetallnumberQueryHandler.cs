using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.ResellerAdminuser.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using RedCloud.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Numbers.Queries
{
    public class GetallnumberQueryHandler:IRequestHandler<GetallNumberQuery, Response<IEnumerable<NumberlistVM>>>
    {
    private readonly ILogger<GetallnumberQueryHandler> _logger;
    private readonly IAsyncRepository<Number> _asyncRepository;
    private readonly IMapper _mapper;


    public GetallnumberQueryHandler(IMapper mapper, ILogger<GetallnumberQueryHandler> logger, IAsyncRepository<Number> asyncRepository)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
        _logger = logger;
    }

        public async  Task<Response<IEnumerable<NumberlistVM>>> Handle(GetallNumberQuery request, CancellationToken cancellationToken)
        {
            //var allnumbers = (await _asyncRepository.GetAllIncludeAsync());
            //var numbers = _mapper.Map<IEnumerable<NumberlistVM>>(allnumbers);
            //_logger.LogInformation("Handle Completed");
            //return new Response<IEnumerable<NumberlistVM>>(numbers, "success");


            var allNumbers = await _asyncRepository.GetAllIncludeAsync();

            // Log details about fetched entities
            foreach (var number in allNumbers)
            {
                _logger.LogInformation($"Phone: {number.PhoneNumber}, Carrier: {number.Carrier?.CarrierName}, Organization: {number.OrganizationAdmin?.OrgName}");
            }

            var numbers = _mapper.Map<IEnumerable<NumberlistVM>>(allNumbers);
            _logger.LogInformation("Handle Completed");
            return new Response<IEnumerable<NumberlistVM>>(numbers, "success");
        }
    }
   
}
