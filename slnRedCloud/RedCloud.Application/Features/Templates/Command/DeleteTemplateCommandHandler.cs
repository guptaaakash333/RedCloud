using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.OrganizationAdmins.Commands;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Templates.Command
{
    public class DeleteTemplateCommandHandler : IRequestHandler<DeleteTemplateCommand, Unit>
    {
        private readonly ILogger<DeleteTemplateCommandHandler> _logger;
        private readonly IAsyncRepository<Template> _asyncRepository;
        private readonly IMapper _mapper;

        public DeleteTemplateCommandHandler(ILogger<DeleteTemplateCommandHandler> logger, IAsyncRepository<Template> asyncRepository, IMapper mapper)
        {
            _logger = logger;
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var templateToDelete = await _asyncRepository.GetByIdAsync(id);
            if (templateToDelete == null)
            {
                //throw new NotFoundException(nameof(ReSellerAdmin),id);
                throw new Exception();
            }

            templateToDelete.IsDeleted = true;
            await _asyncRepository.UpdateAsync(templateToDelete);
            return Unit.Value;
        }
    }
}
