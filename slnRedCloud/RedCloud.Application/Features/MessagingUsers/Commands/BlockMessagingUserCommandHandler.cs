using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.OrganizationUsers.Commands;
using RedCloud.Application.Features.ResellerAdminuser.Commands;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.MessagingUsers.Commands
{
    public class BlockMessagingUserCommandHandler : IRequestHandler<BlockMessagingUserCommand,Unit>
    {



        private readonly ILogger<BlockMessagingUserCommandHandler> _logger;
        private readonly IAsyncRepository<MessagingUser> _asyncRepository;
        private readonly IMapper _mapper;


        public BlockMessagingUserCommandHandler(IMapper mapper, ILogger<BlockMessagingUserCommandHandler> logger, IAsyncRepository<MessagingUser> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(BlockMessagingUserCommand request, CancellationToken cancellationToken)
        {
          
            var id = request.Id;

            var Blockeduser = await _asyncRepository.GetByIdAsync(id)
;
            if (Blockeduser == null)
            {
                throw new Exception();
            }
            //if (Blockeduser.IsActive == false)
            //{
            //    Blockeduser.IsActive = true;
                
            //}
            //if (Blockeduser.IsActive == true)
            //{
            //    Blockeduser.IsActive = false;
            //}

            switch (Blockeduser.IsActive)
            {
                case false:
                    Blockeduser.IsActive = true;
                    break;
                case true:
                    Blockeduser.IsActive = false;
                    break;
            }


            await _asyncRepository.UpdateAsync(Blockeduser);
            return Unit.Value;
        }


    }
}

