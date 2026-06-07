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
    public class DeleteOrganizationAdminHandler : IRequestHandler<DeleteOrganizationAdminCommand, Unit>
    {

        private readonly ILogger<DeleteOrganizationAdminHandler> _logger;
        private readonly IAsyncRepository<OrganizationAdmin> _asyncRepository;
        private readonly IMapper _mapper;

        public DeleteOrganizationAdminHandler(ILogger<DeleteOrganizationAdminHandler> logger, IAsyncRepository<OrganizationAdmin> asyncRepository, IMapper mapper)
        {
            _logger = logger;
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOrganizationAdminCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var AdminToDelete = await _asyncRepository.GetByIdAsync(id);
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
