using AutoMapper;
using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.OrganizationAdmins.Commands;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Templates.Command
{
    public class UpdateTemplateCommandHandler : IRequestHandler<UpdateTemplateCommand, Response<int>>
    {

        private readonly IAsyncRepository<Template> _repository;
        private readonly IMapper _mapper;


        public UpdateTemplateCommandHandler(IAsyncRepository<Template> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateTemplateCommand request, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(request.TemplateId);
            //var reseller = (await _repository.ListAllAsync()).FirstOrDefault(x => x.TemplateId == request.TemplateId);
            
           
            _mapper.Map(request, model, typeof(UpdateTemplateCommand), typeof(Template));

            model.LastModifiedBy = request.SessionId;
            model.LastModifiedDate = DateTime.Now;
            await _repository.UpdateAsync(model);

            
            var response = new Response<int>("Inserted successfully");
            return response; 
        }
    }
}
