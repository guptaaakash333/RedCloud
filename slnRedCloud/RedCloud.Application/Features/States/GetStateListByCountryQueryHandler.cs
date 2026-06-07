using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.States
{
    public class GetStateListByCountryQueryHandler : IRequestHandler<GetStateListByCountryQuery, Response<IEnumerable<State>>>
    {
        private readonly ILogger<GetStateListByCountryQueryHandler> _logger;
        private readonly IAsyncRepository<State> _asyncRepository;
        private readonly IMapper _mapper;
        public GetStateListByCountryQueryHandler(IMapper mapper, ILogger<GetStateListByCountryQueryHandler> logger, IAsyncRepository<State> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<IEnumerable<State>>> Handle(GetStateListByCountryQuery request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Handle Initiated");
            var list = (await _asyncRepository.ListAllAsync()).Where(x => x.CountryId == request.CountryId).ToList();
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<State>>(list, "success");
        }
    }
}
