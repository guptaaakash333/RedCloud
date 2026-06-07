using AutoMapper;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.Types.Queries;
using RedCloud.Application.Features.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RedCloud.Application.Responses;

namespace RedCloud.Application.Features.Carrierss.Queries
{
    public class GetallCarrierListCommandHandler : IRequestHandler<GetallCarrierListCommand, Response<IEnumerable<CarrierVM>>>

    {
        private readonly ILogger<GetallCarrierListCommandHandler> _logger;
        private readonly IAsyncRepository<RedCloud.Domain.Entities.Carrier> _asyncRepository;
        private readonly IMapper _mapper;
        public GetallCarrierListCommandHandler(IMapper mapper, ILogger<GetallCarrierListCommandHandler> logger, IAsyncRepository<RedCloud.Domain.Entities.Carrier> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }


        

        public async Task<Response<IEnumerable<CarrierVM>>> Handle(GetallCarrierListCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allCountry = (await _asyncRepository.ListAllAsync()).ToList();
            var country = _mapper.Map<IEnumerable<CarrierVM>>(allCountry);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<CarrierVM>>(country, "success");
        }
    }
}