using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.OrganizationAdmins.Commands;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RedCloud.Application.Features.Campaigns.Commands
{
    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, Response<int>>
    {
        private readonly IAsyncRepository<Campaign> _asyncRepository;
        private readonly IMapper _mapper;


        public CreateCampaignCommandHandler(IAsyncRepository<Campaign> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }


        public async Task<Response<int>> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            var campaign = _mapper.Map<Campaign>(request);
            //campaign.CreatedBy = HttpContext.Session.GetInt32("UserId");
            campaign.CreatedBy = request.userID;
            campaign.CreatedDate = DateTime.Now;
            campaign.IsDeleted = false;
            var result = await _asyncRepository.AddAsync(campaign);
            var response = new Response<int>(result.CampaignId, "Inserted successfully ");
            return response;
        }


    }
}
