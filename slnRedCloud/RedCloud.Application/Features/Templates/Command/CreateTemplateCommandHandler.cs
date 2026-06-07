using AutoMapper;
using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Templates.Command
{
    public class CreateTemplateCommandHandler : IRequestHandler<CreateTemplateCommand, Response<int>>
    {
        private readonly IAsyncRepository<Template> _repository;
        private readonly IMapper _mapper;

        public CreateTemplateCommandHandler(IAsyncRepository<Template> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
        {
            var template = _mapper.Map<Template>(request);
            //  adminuser.Password = encryptedPassword;

            template.IsDeleted = false;
            template.CreatedDate = DateTime.Now;
            template.CreatedBy = request.SessionId;
            
            var result = await _repository.AddAsync(template);
            var response = new Response<int>(result.TemplateId, "Inserted successfully");
            return response;
        }
    }
}
