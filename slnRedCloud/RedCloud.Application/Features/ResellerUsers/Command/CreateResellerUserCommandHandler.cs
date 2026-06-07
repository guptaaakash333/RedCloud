using AutoMapper;
using MediatR;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Features.RedCloudAdmins.Commands.CreateRedCloudAdmin;
using RedCloud.Application.Features.ResellerUsers.Queries;
using RedCloud.Application.Helper;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.ResellerUsers.Command
{
    public class CreateResellerUserCommandHandler : IRequestHandler<CreateResellerUserCommand, Response<int>>
    {
        private readonly IAsyncRepository<ResellerUser> _repository;
        private readonly IMapper _mapper;

        public CreateResellerUserCommandHandler(IAsyncRepository<ResellerUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateResellerUserCommand request, CancellationToken cancellationToken)
        {
            //request.Password = GenerateRandomPassword();
           // var encryptedPassword = EncryptionDecryption.EncryptString(request.Password);

            var reselleruser = _mapper.Map<ResellerUser>(request);
            //  adminuser.Password = encryptedPassword;



            reselleruser.CreatedDate = DateTime.UtcNow;
            reselleruser.CreatedBy = null;
            reselleruser.IsActive= true;


            var result = await _repository.AddAsync(reselleruser);
            var response = new Response<int>(result.ResellerUserId, "Inserted successfully");
            return response;
        }

        //private string GenerateRandomPassword()
        //{
        //    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        //    var random = new Random();
        //    var password = new string(Enumerable.Repeat(chars, 8)
        //        .Select(s => s[random.Next(s.Length)]).ToArray());
        //    return password;
        //}
    }
}
