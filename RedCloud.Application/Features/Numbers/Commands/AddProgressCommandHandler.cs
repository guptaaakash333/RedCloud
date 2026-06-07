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

namespace RedCloud.Application.Features.Numbers.Commands
{
    public class AddProgressCommandHandler : IRequestHandler<AddProgressCommand, Response<Unit>>
    {
        private readonly IAsyncRepository<Number> _asyncRepository;
        private readonly IMapper _mapper;

        public AddProgressCommandHandler(IAsyncRepository<Number> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;

        }

        public async Task<Response<Unit>> Handle(AddProgressCommand request, CancellationToken cancellationToken)
        {
            var model = await _asyncRepository.GetByIdAsync(request.NumberId);
            model.NumberId = request.NumberId;
            model.Status= request.Status;
            await _asyncRepository.UpdateAsync(model);
            var response = new Response<Unit>("Updated Successfully");
            return response;
        }
    }
}
