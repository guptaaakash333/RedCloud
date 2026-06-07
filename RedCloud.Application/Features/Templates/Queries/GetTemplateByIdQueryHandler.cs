using AutoMapper;
using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.OrganizationAdmins.Queries;
using RedCloud.Application.Features.OrganizationUsers.Queries;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Templates.Queries
{
    public class GetTemplateByIdQueryHandler : IRequestHandler<GetTemplateByIdQuery, Response<GetTemplateVM>>
    {
        private readonly IAsyncRepository<Template> _asyncRepository;
        private readonly IMapper _mapper;


        public GetTemplateByIdQueryHandler(IAsyncRepository<Template> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<Response<GetTemplateVM>> Handle(GetTemplateByIdQuery request, CancellationToken cancellationToken)
        {

            var temp = await _asyncRepository.GetByIdAsync(request.Id);
           // var reseller = (await _asyncRepository.ListAllAsync()).FirstOrDefault(x => x.TemplateId == request.Id);
            if (temp == null)
            {
                return null;
            }

            var dto = new GetTemplateVM()
            {
             TemplateId = request.Id,
             TemplateName = temp.TemplateName,
             TemplatePersonalization = temp.TemplatePersonalization,
             MessageType = temp.MessageType,
             MessageBody = temp.MessageBody,
             TemplateURL = temp.TemplateURL,


            };

            return new Response<GetTemplateVM>(dto, "Successful");
        }
    }
}
