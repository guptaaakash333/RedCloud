using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Campaigns
{
    public class DeleteCampaignByIdCommandHandler : IRequestHandler<DeleteCampaignByIdCommand, Unit>
    {
        private readonly ILogger<DeleteCampaignByIdCommandHandler> _logger;
        private readonly IAsyncRepository<Campaign> _asyncRepository;  // Add entity name
        private readonly IMapper _mapper;


        public DeleteCampaignByIdCommandHandler(IMapper mapper, ILogger<DeleteCampaignByIdCommandHandler> logger, IAsyncRepository<Campaign> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCampaignByIdCommand request, CancellationToken cancellationToken)
        {
            var id = request.CampaignId;

            var CampaignToDelete = await _asyncRepository.GetByIdAsync(id);

            if (CampaignToDelete == null)
            {
                //throw new NotFoundException(nameof(ReSellerAdmin),id);
                throw new Exception();
            }
           // CampaignToDelete.IsActive = false;
            CampaignToDelete.IsDeleted = true;
            await _asyncRepository.UpdateAsync(CampaignToDelete);
            return Unit.Value;
        }
    }
}
