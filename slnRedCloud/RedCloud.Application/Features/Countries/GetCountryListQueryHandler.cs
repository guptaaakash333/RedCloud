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

namespace RedCloud.Application.Features.Countries
{
    public class GetCountryListQueryHandler : IRequestHandler<GetCountryList, Response<IEnumerable<CountryListVM>>>
    {
        private readonly ILogger<GetCountryListQueryHandler> _logger;
        private readonly IAsyncRepository<Country> _asyncRepository;
        private readonly IMapper _mapper;
        public GetCountryListQueryHandler(IMapper mapper, ILogger<GetCountryListQueryHandler> logger, IAsyncRepository<Country> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<IEnumerable<CountryListVM>>> Handle(GetCountryList request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Handle Initiated");
            var allCountry = (await _asyncRepository.ListAllAsync()).ToList();
            var country = _mapper.Map<IEnumerable<CountryListVM>>(allCountry);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<CountryListVM>>(country, "success");
        }


    }
}
