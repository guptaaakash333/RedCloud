using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RedCloud.Application.Contract.Infrastructure;
using RedCloud.Application.Contract.Persistence;
using RedCloud.Application.Helper;
using RedCloud.Application.Models.Mail;
using RedCloud.Application.Responses;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Features.ResellerAdminuser.Commands
{

    public class CreateresellerAdminUserCommandHandler : IRequestHandler<CreateResellerAdminUserCommand, Response<int>>
    {


        private readonly IAsyncRepository<ResellerAdminUser> _repository;
        private readonly IMapper _mapper;


        public CreateresellerAdminUserCommandHandler(IAsyncRepository<ResellerAdminUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateResellerAdminUserCommand request, CancellationToken cancellationToken)
        {
            request.Password = GenerateRandomPassword();//create for random passaword generation new adition

           
            var encryptedPassword = EncryptionDecryption.EncryptString(request.Password);

            var AdminRese = _mapper.Map<ResellerAdminUser>(request);
            AdminRese.Password = encryptedPassword;

            //var AdminRese = _mapper.Map<ResellerAdminUser>(request);


            //  ResellerName = request.ResellerName,
            AdminRese.IsActive = true;
            AdminRese.CreatedBy = 1;//c.n
            AdminRese.CreatedDate = DateTime.Now;
            AdminRese.IsDeleted = false;

            var result = await _repository.AddAsync(AdminRese);

            //Sending email notification to admin address
            //var email = new Email() { To = AdminRese.CompanySupportEmail, Body = $"A new event was created: {request}", Subject = $"Your Account is created with: Email:{AdminRese.CompanySupportEmail} and Your Password is :{AdminRese.Password}" };

            //try
            //{
            //    await _emailService.SendEmail(email);
            //}
            //catch (Exception ex)
            //{
            //    //this shouldn't stop the API from doing else so this can be logged
            //    //.LogError($"Mailing about event {@event.EventId} failed due to an error with the mail service: {ex.Message}");
            //}


            //var response = new Response<BlogVM>(_mapper.Map<BlogVM>(blog), "Inserted successfully ");
            var response = new Response<int>(result.ResellerAdminUserId, "Inserted successfully ");
            return response;

        }

        private string GenerateRandomPassword()
        {
            const int passwordLength = 12;
            const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";

            var random = new Random();
            return new string(Enumerable.Repeat(allowedChars, passwordLength)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

}

