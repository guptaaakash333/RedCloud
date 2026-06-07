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

namespace RedCloud.Application.Features.Rates.Queries
{
    //public class GetAllRatesQueryHandler : IRequestHandler<GetAllRatesQuery,IEnumerable<GetRate>>
    //{
    //    private readonly IAsyncRepository<GetRate> _rateRepository;
    //    private readonly IMapper _mapper;
    //    private readonly ILogger<GetAllRatesQueryHandler> _logger;

    //    public GetAllRatesQueryHandler(IAsyncRepository<GetRate> rateRepository, IMapper mapper, ILogger<GetAllRatesQueryHandler> logger)
    //    {
    //        _rateRepository = rateRepository;
    //        _mapper = mapper;
    //        _logger = logger;
    //    }

    //    public async Task<IEnumerable<GetRate>> Handle(GetAllRatesQuery request, CancellationToken cancellationToken)
    //    {
    //        try
    //        {
    //            _logger.LogInformation("Fetching all rates");
    //            var rates = await _rateRepository.StoredProcedureQueryAsync("GetAllRates");

    //            return rates;
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }

    //    }
    //}
    public class GetAllRatesQueryHandler : IRequestHandler<GetAllRatesQuery, Response<IEnumerable<GetRate>>>
    {
        private readonly IAsyncRepository<GetRate> _rateRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllRatesQueryHandler> _logger;

        public GetAllRatesQueryHandler(IAsyncRepository<GetRate> rateRepository, IMapper mapper, ILogger<GetAllRatesQueryHandler> logger)
        {
            _rateRepository = rateRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<GetRate>>> Handle(GetAllRatesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Fetching all rates");
                var rates = await _rateRepository.StoredProcedureQueryAsync("GetAllRates");

                // Adjusting the response construction
                return new Response<IEnumerable<GetRate>>(rates, "Fetched successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all rates");
                return new Response<IEnumerable<GetRate>>(null, "An error occurred");
            }
        }
    }
}
