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

namespace RedCloud.Application.Features.RedCloudAdmins.Commands
{
    public class DeleteRedCloudAdminCommandHandler : IRequestHandler<DeleteRedCloudAdminCommand, Unit>
    {

        private readonly ILogger<DeleteRedCloudAdminCommandHandler> _logger;
        private readonly IAsyncRepository<RedCloudAdmin> _asyncRepository;
        private readonly IMapper _mapper;


        public DeleteRedCloudAdminCommandHandler(IMapper mapper, ILogger<DeleteRedCloudAdminCommandHandler> logger, IAsyncRepository<RedCloudAdmin> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteRedCloudAdminCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var AdminToDelete = await _asyncRepository.GetByIdAsync(id)
;
            if (AdminToDelete == null)
            {
                //throw new NotFoundException(nameof(ReSellerAdmin),id);
                throw new Exception();
            }
            AdminToDelete.IsActive = false;
            AdminToDelete.IsDeleted = true;
            await _asyncRepository.UpdateAsync(AdminToDelete);
            return Unit.Value;
        }


    }
}
