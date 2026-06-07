using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RedCloud.Domain.Entities;

namespace RedCloud.Application.Features.Cities.Queries
{
    public class GetCityListByStateIdQueryHandler : IRequestHandler<GetCityListByStateId, Response<IEnumerable<CityListVM>>>
    {
        private readonly ILogger<GetCityListByStateIdQueryHandler> _logger;
        private readonly IAsyncRepository<City> _asyncRepository;
        private readonly IMapper _mapper;
        public GetCityListByStateIdQueryHandler(IMapper mapper, ILogger<GetCityListByStateIdQueryHandler> logger, IAsyncRepository<City> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<IEnumerable<CityListVM>>> Handle(GetCityListByStateId request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Handle Initiated");
            var allCountry = (await _asyncRepository.ListAllAsync()).Where(x => x.StateId == request.StateId).ToList();
            var country = _mapper.Map<IEnumerable<CityListVM>>(allCountry);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<CityListVM>>(country, "success");
        }
    }
}
