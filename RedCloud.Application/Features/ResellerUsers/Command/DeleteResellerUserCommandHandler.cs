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

namespace RedCloud.Application.Features.ResellerUsers.Command
{
    public class DeleteResellerUserCommandHandler : IRequestHandler<DeleteResellerUserCommand, Unit>

    {


        private readonly ILogger<DeleteReSellerAdminCommandHandler> _logger;
        private readonly IAsyncRepository<ResellerUser> _asyncRepository;
        private readonly IMapper _mapper;


        public DeleteResellerUserCommandHandler(IMapper mapper, ILogger<DeleteReSellerAdminCommandHandler> logger, IAsyncRepository<ResellerUser> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteResellerUserCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var ResellerUserToDelete = await _asyncRepository.GetByIdAsync(id)
;
            if (ResellerUserToDelete == null)
            {
                //throw new NotFoundException(nameof(ReSellerAdmin),id);
                throw new Exception();
            }
            ResellerUserToDelete.IsActive = false;
            ResellerUserToDelete.IsDeleted = true;
            await _asyncRepository.UpdateAsync(ResellerUserToDelete);
            return Unit.Value;
        }
    }
}
