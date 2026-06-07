using AutoMapper;
using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Helper;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.RedCloudAdmins.Commands.CreateRedCloudAdmin
{
    public class CreateRedCloudAdminCommandHandler : IRequestHandler<CreateRedCloudAdminCommand, Response<int>>
    {
        private readonly IAsyncRepository<RedCloudAdmin> _repository;
        private readonly IMapper _mapper;

        public CreateRedCloudAdminCommandHandler(IAsyncRepository<RedCloudAdmin> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateRedCloudAdminCommand request, CancellationToken cancellationToken)
        {
            request.Password = GenerateRandomPassword();
            var encryptedPassword = EncryptionDecryption.EncryptString(request.Password);
            
            var adminuser = _mapper.Map<RedCloudAdmin>(request);
            adminuser.Password = encryptedPassword;



            adminuser.CreatedDate = DateTime.UtcNow;
            adminuser.CreatedBy = null;



            var result = await _repository.AddAsync(adminuser);
            var response = new Response<int>(result.RedCloudAdminUserId, "Inserted successfully");
            return response;
        }

        private string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var password = new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return password;
        }
    }
}
