using Microsoft.Win32;
using MvcApiCallingService.Models.Responses;
using RedCloud.Application.Features.Account.Queries.LoginQuery;
using RedCloud.Domain.Common;
using RedCloud.Domain.Entities;
using RedCloud.ViewModel;

namespace RedCloud.Interfaces
{
    public interface IAccountService
    {
        Task<Response<UserVM>> Login(LoginVM login);

        //Task<Register> Register(Register register);
        //Task<LoginResponse> Login(Login login);
        //Task<Register> Register(Register register);

        Task<Response<ResetUserPasswordVM>> ForgetUserPasswordService(ResetUserPasswordVM model);
        Task<User> CheckUserExistByEmail(string email);

    }
}
