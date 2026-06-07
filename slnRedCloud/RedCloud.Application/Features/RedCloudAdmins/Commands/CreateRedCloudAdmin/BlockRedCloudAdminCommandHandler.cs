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

namespace RedCloud.Application.Features.RedCloudAdmins.Commands.CreateRedCloudAdmin
{
    public class BlockRedCloudAdminCommandHandler : IRequestHandler<BlockRedCloudAdminCommand, Unit>
    {

        private readonly ILogger<BlockRedCloudAdminCommandHandler> _logger;
        private readonly IAsyncRepository<RedCloudAdmin> _asyncRepository;
        private readonly IMapper _mapper;


        public BlockRedCloudAdminCommandHandler(IMapper mapper, ILogger<BlockRedCloudAdminCommandHandler> logger, IAsyncRepository<RedCloudAdmin> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(BlockRedCloudAdminCommand request, CancellationToken cancellationToken)
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
