using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Responses;
using RedCloud.Application.Contracts.Persistence;
using RedCloud.Application.Helper;

using RedCloud.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.Account.Queries.LoginQuery
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, Response<UserVM>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<LoginQueryHandler> _logger;

        public LoginQueryHandler(IAccountRepository accountRepository, IMapper mapper, ILogger<LoginQueryHandler> logger)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<UserVM>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var Encryptedpass = EncryptionDecryption.EncryptString(request.Password);

            var user = (await _accountRepository.Get(request.Email, Encryptedpass));

            if (user == null)
            {
                return new Response<UserVM>("no user found ");
            }
            else
            {
                return new Response<UserVM>(user, "success");
            }
        }
    }
}
