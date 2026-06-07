using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.Countries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Types.Queries
{
    public class GetAllTypesCommandHandler : IRequestHandler<GetallTypesCommand, Response<IEnumerable<TypesVM>>>
    {
        private readonly ILogger<GetAllTypesCommandHandler> _logger;
        private readonly IAsyncRepository<RedCloud.Domain.Entities.Types> _asyncRepository;
        private readonly IMapper _mapper;
        public GetAllTypesCommandHandler(IMapper mapper, ILogger<GetAllTypesCommandHandler> logger, IAsyncRepository<RedCloud.Domain.Entities.Types> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<Response<IEnumerable<TypesVM>>> Handle(GetallTypesCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Handle Initiated");
            var allCountry = (await _asyncRepository.ListAllAsync()).ToList();
            var country = _mapper.Map<IEnumerable<TypesVM>>(allCountry);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<TypesVM>>(country, "success");

        }
    }
}
