using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.ResellerAdminuser.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Campaign
{
    public class GetallCampaignQueryHandler : IRequestHandler<GetallCampaignCommand, Response<IEnumerable<CampaignVM>>>

    {
        private readonly ILogger<GetallCampaignQueryHandler> _logger;
        private readonly IAsyncRepository<RedCloud.Domain.Entities.Campaign> _asyncRepository;
        private readonly IMapper _mapper;


        public GetallCampaignQueryHandler(IMapper mapper, ILogger<GetallCampaignQueryHandler> logger, IAsyncRepository<RedCloud.Domain.Entities.Campaign> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }

       

        public async Task<Response<IEnumerable<CampaignVM>>> Handle(GetallCampaignCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allcampaign = (await _asyncRepository.ListAllAsync()).Where(x => x.IsDeleted == false);
            var campaign = _mapper.Map<IEnumerable<CampaignVM>>(allcampaign);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<CampaignVM>>(campaign, "success");
        }
    }
}
