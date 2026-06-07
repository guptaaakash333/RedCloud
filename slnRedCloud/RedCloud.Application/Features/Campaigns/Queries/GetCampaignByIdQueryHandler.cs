using AutoMapper;
using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.OrganizationAdmins.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Campaigns.Queries
{
    public class GetCampaignByIdQueryHandler : IRequestHandler<GetCampaignByIdQuery, Response<CampaignDetailsVM>>
    {
        private readonly IAsyncRepository<Campaign> _asyncRepository;
        private readonly IMapper _mapper;

        public GetCampaignByIdQueryHandler(IAsyncRepository<Campaign> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;

        }


        public async Task<Response<CampaignDetailsVM>> Handle(GetCampaignByIdQuery request, CancellationToken cancellationToken)
        {
            var campaign = await _asyncRepository.GetByIdAsyncInculde(request.Id);
            try
            {
                if (campaign == null)
                {
                    return new Response<CampaignDetailsVM>("Campaign Details not found");
                }

                var dto = new CampaignDetailsVM()
                {
                    CampaignId = campaign.CampaignId,
                    OrganizationUserName = campaign.OrganizationUser.OrganizationUserFirstName,
                    ResellerUserName = campaign.ResellerUser.FirstName,
                    CompanyName = campaign.CompanyName,
                    UniversalEIN = campaign.UniversalEIN,
                    BrandId = campaign.BrandId,
                    IdentityStatus = campaign.IdentityStatus,
                    BrandRelationship = campaign.BrandRelationship,
                    BrandRegistrationDate = campaign.BrandRegistrationDate,
                    CampaignIdOne = campaign.CampaignIdOne,
                    UseCaseOne = campaign.UseCaseOne,
                    RegistrationDateOne = campaign.RegistrationDateOne,
                    RenewalDateOne = campaign.RenewalDateOne,
                    CampaignDescriptionOne = campaign.CampaignDescriptionOne,
                    CampaignIdTwo = campaign.CampaignIdTwo,
                    UseCaseTwo = campaign.UseCaseTwo,
                    RegistrationDateTwo = campaign.RegistrationDateTwo,
                    RenewalDateTwo = campaign.RenewalDateTwo,
                    CampaignDescriptionTwo = campaign.CampaignDescriptionTwo,

                };
                return new Response<CampaignDetailsVM>(dto);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
