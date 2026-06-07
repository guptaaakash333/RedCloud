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

namespace RedCloud.Application.Features.ResellerAdminuser.Commands
{
    public class DeleteReSellerAdminCommandHandler : IRequestHandler<DeleteReSellerAdminCommand, Unit>
    {

        private readonly ILogger<DeleteReSellerAdminCommandHandler> _logger;
        private readonly IAsyncRepository<ResellerAdminUser> _asyncRepository;
        private readonly IMapper _mapper;


        public DeleteReSellerAdminCommandHandler(IMapper mapper, ILogger<DeleteReSellerAdminCommandHandler> logger, IAsyncRepository<ResellerAdminUser> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteReSellerAdminCommand request, CancellationToken cancellationToken)
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
