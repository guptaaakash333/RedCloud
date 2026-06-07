using Microsoft.AspNetCore.Http.HttpResults;
using MvcApiCallingService.Helpers.ApiHelper;
using MvcApiCallingService.Models.Responses;
using RedCloud.Application.Features.Account.Queries.LoginQuery;
using RedCloud.Domain.Common;
using RedCloud.Domain.Entities;
using RedCloud.Interfaces;
using RedCloud.ViewModel;

namespace RedCloud.Services
{
    public class AccountService : IAccountService
    {
        private readonly IApiClient<UserVM> _apiClientLogin;
        //private readonly IApiClient<Register> _apiClientRegister;
        private readonly ILogger<AccountService> _logger;
        private readonly IApiClient<ForgetUserPasswordVM> _apiClientForget;
        private readonly IApiClient<User> _apiClientUserForget;


        public AccountService(IApiClient<UserVM> apiClientLogin, ILogger<AccountService> logger, IApiClient<ForgetUserPasswordVM> apiClientForget, IApiClient<User> apiClientUserForget)
        {
            _apiClientLogin = apiClientLogin;
            _logger = logger;
            _apiClientForget = apiClientForget;
            _apiClientUserForget = apiClientUserForget;
            //_apiClientRegister = apiClientRegister;
        }


        public async Task<Response<UserVM>> Login(LoginVM login)
        {
            //_logger.LogInformation("LoginAccount Service initiated");
            var response = await _apiClientLogin.PostAuthAsync("Account/Login", login);
            var responseTwo = await _apiClientLogin.PostAuthAsync("Account/ResellerAdminLogin", login);
            var responsethree = await _apiClientLogin.PostAuthAsync("Account/OrganizationAdminLogin", login);

            if(response.Data != null)
            {
                //_logger.LogInformation("LoginAccount Service conpleted");
                return response;
            }
            else if(responseTwo.Data != null)
            {
                return responseTwo;
            }
            else if (responsethree.Data != null)
            {
                return responsethree;
            }
            else
            {
                //return new Response<UserVM>(null, "InvalId login credentials");
                return new Response<UserVM>("InvalId login credentials");
            }

            //if (response.Data == null)
            //{
            //    var responseTwo = await _apiClientLogin.PostAuthAsync("Account/ResellerAdminLogin", login);
            //    if(responseTwo == null)
            //    {
            //        return new Response<UserVM>(null, "InvalId login credentials");

            //    }
            //    //_logger.LogInformation("LoginAccount Service completed with failure");
            //    return responseTwo;
            //}

            //_logger.LogInformation("LoginAccount Service conpleted");
            //return response;
        }

        public async Task<Response<ResetUserPasswordVM>> ForgetUserPasswordService(ResetUserPasswordVM model)
        {
            _logger.LogInformation("LoginAccount Service initiated");
            var response = await _apiClientLogin.PostAuthAsync("Account/ResetUserPassword", model);
            if (response == null)
            {
                _logger.LogInformation("LoginAccount Service completed with failure");
                return new Response<ResetUserPasswordVM>(null, "InvalId login credentials");
            }

            _logger.LogInformation("LoginAccount Service conpleted");
            return new Response<ResetUserPasswordVM>("ForgetUserPassword credentials");
            //return response;
        }

        public async Task<User> CheckUserExistByEmail(string email)
        {
            var rate = await _apiClientUserForget.GetByIdAsync("Account/CheckUserExistByEmail/" + email);
            return rate.Data;
        }






        //public async Task<Register> Register(Register register)
        //{
        //    _logger.LogInformation("RegisterAccount Service initiated");
        //    var response = await _apiClientRegister.PostAuthAsync("Account/register", register);
        //    if (response == null)
        //    {
        //        //Register registerResponse = new Register();
        //        register.Message = $" UserName {register.UserName} or Email {register.Email} already exist";
        //        return register;
        //    }
        //    _logger.LogInformation("RegisterAccount Service conpleted");
        //    return response;

        //}


    }
}
