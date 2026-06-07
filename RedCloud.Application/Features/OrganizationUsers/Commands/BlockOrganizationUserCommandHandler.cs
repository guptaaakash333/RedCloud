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

namespace RedCloud.Application.Features.OrganizationUsers.Commands
{
    public class BlockOrganizationUserCommandHandler : IRequestHandler<BlockOrganizationUserCommand, Unit>
    {


        private readonly ILogger<BlockReSellerAdminCommandHandler> _logger;
        private readonly IAsyncRepository<OrganizationUser> _asyncRepository;
        private readonly IMapper _mapper;


        public BlockOrganizationUserCommandHandler(IMapper mapper, ILogger<BlockReSellerAdminCommandHandler> logger, IAsyncRepository<OrganizationUser> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(BlockOrganizationUserCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var Blockeduser = await _asyncRepository.GetByIdAsync(id)
;
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
