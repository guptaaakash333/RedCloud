using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.OrganizationAdmins.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Templates.Queries
{
    public class GetAllTemplateQueryHandler : IRequestHandler<GetAllTemplateQuery, Response<IEnumerable<GetTemplateVM>>>
    {
        private readonly ILogger<GetAllTemplateQueryHandler> _logger;
        private readonly IAsyncRepository<Template> _asyncRepository;
        private readonly IMapper _mapper;

        public GetAllTemplateQueryHandler(ILogger<GetAllTemplateQueryHandler> logger, IAsyncRepository<Template> asyncRepository, IMapper mapper)
        {
            _logger = logger;
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

     

        public async Task<Response<IEnumerable<GetTemplateVM>>> Handle(GetAllTemplateQuery request, CancellationToken cancellationToken)
        {
            var allTempalates = (await _asyncRepository.ListAllAsync()).Where(x => x.IsDeleted == false);
            var temp = _mapper.Map<IEnumerable<GetTemplateVM>>(allTempalates);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<GetTemplateVM>>(temp, "success");
        }
    }
}
