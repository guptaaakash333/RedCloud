using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.OrganizationAdmins.Queries;
using RedCloud.Application.Features.RedCloudAdmins.Commands.CreateRedCloudAdmin;
using RedCloud.Application.Features.RedCloudAdmins.Queries;
using RedCloud.Application.Features.ResellerAdminuser.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Campaigns.Queries
{
    public class GetAllCampaignQueriesHandler : IRequestHandler<GetAllCampaignQueries, Response<IEnumerable<CampaignVM>>>
    {
        private readonly ILogger<GetAllCampaignQueriesHandler> _logger;
        private readonly IAsyncRepository<Campaign> _asyncRepository;
        private readonly IMapper _mapper;


        public GetAllCampaignQueriesHandler(IMapper mapper, ILogger<GetAllCampaignQueriesHandler> logger, IAsyncRepository<Campaign> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<CampaignVM>>> Handle(GetAllCampaignQueries request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handle Initiated");
                var allCampaign = (await _asyncRepository.ListAllAsync()).Where(x => x.IsDeleted == false);
                var allCAmp = _mapper.Map<IEnumerable<CampaignVM>>(allCampaign);
                _logger.LogInformation("Hanlde Completed");
                return new Response<IEnumerable<CampaignVM>>(allCAmp, "success");
            }
            catch (Exception)
            {

                throw;
            }
        }







    }
}
