using RedCloud.Application.Features.ResellerAdminuser.Queries;
using RedCloud.Domain.Common;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Contracts.Persistence
{
    public interface IAccountRepository
    {
        Task<UserVM> Get(string Email, string Password);

        Task<UserVM> GetResellerAdmin(string Email, string Password);

        Task<UserVM> GetOrganizationAdmin(string Email, string Password);



 
    }
}
