using AutoMapper;
using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.Numbers.Commands;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.AssignNumberToUser.Commands
{
    public class AssignNumberToUserCommandHandler : IRequestHandler<AssignNumberToUserCommand, Response<int>>
    {
        private readonly IAsyncRepository<UsersNumberMapper> _asyncRepository;
        private readonly IMapper _mapper;

        public AssignNumberToUserCommandHandler(IAsyncRepository<UsersNumberMapper> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(AssignNumberToUserCommand request, CancellationToken cancellationToken)
        {
            int totalInserted = 0;

            foreach (var item in request.MessagingUserId)
            {
                var UserNumber = new AssignNumberDto()
                {
                    NumberId = request.NumberId,
                    MessagingUserId = item
                };

                var userData = _mapper.Map<UsersNumberMapper>(UserNumber);
                var result = await _asyncRepository.AddAsync(userData);

                if (result != null) // assuming AddAsync returns the added entity or null if it fails
                {
                    totalInserted++;
                }
            }

            var response = new Response<int>(totalInserted, "User with Number Inserted successfully");
            return response;
        }
    }
    
}
