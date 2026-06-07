using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.ResellerAdminuser.Commands;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationAdmins.Commands
{
    public class BlockOrganizationAdminHandler : IRequestHandler<BlockOrganizationAdminCommand, Unit>
    {
        private readonly ILogger<BlockReSellerAdminCommandHandler> _logger;
        private readonly IAsyncRepository<OrganizationAdmin> _asyncRepository;
        private readonly IMapper _mapper;

        public BlockOrganizationAdminHandler(IAsyncRepository<OrganizationAdmin> asyncRepository, ILogger<BlockReSellerAdminCommandHandler> logger, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(BlockOrganizationAdminCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var Blockeduser = await _asyncRepository.GetByIdAsync(id);
            if (Blockeduser == null)
            {
                throw new Exception();
            }
            Blockeduser.IsActive = false;

            await _asyncRepository.UpdateAsync(Blockeduser);
            return Unit.Value;
        }
    }
}
