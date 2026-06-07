using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.ResellerAdminuser.Commands;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.OrganizationUsers.Commands
{
    public class DeleteOrganizationUserCommandHandler : IRequestHandler<DeleteOrganizationUserCommand, Unit>
    {



        private readonly ILogger<DeleteReSellerAdminCommandHandler> _logger;
        private readonly IAsyncRepository<OrganizationUser> _asyncRepository;
        private readonly IMapper _mapper;


        public DeleteOrganizationUserCommandHandler(IMapper mapper, ILogger<DeleteReSellerAdminCommandHandler> logger, IAsyncRepository<OrganizationUser> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteOrganizationUserCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var OrganizationUserToDelete = await _asyncRepository.GetByIdAsync(id)

;
            if (OrganizationUserToDelete == null)
            {
                //throw new NotFoundException(nameof(ReSellerAdmin),id);
                throw new Exception();
            }
            OrganizationUserToDelete.IsActive = false;
            OrganizationUserToDelete.IsDeleted = true;
            await _asyncRepository.UpdateAsync(OrganizationUserToDelete);
            return Unit.Value;
        }

      
    }
}
