using Microsoft.Extensions.Logging;
using RedCloud.Application.Contracts.Persistence;
using RedCloud.Application.Features.ResellerAdminuser.Queries;
using RedCloud.Domain.Common;
using RedCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Persistenence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _dbContex;

        public AccountRepository(ApplicationDbContext dbContex, ILogger<User> logger)
        {
            _dbContex = dbContex;
            _logger = logger;
        }


        public async Task<UserVM> Get(string Email, string Password)
        {
            ////----
            //var user = _dbContex.User.Where(x => x.Email == Email && x.Password== Encryptedpass).FirstOrDefault();
            //var userData = _dbContex.User.Where(x =>x.Email == Email).FirstOrDefault();
            //var DecryptedPass = EncryptionDecryption.DecryptString(userData.Password);

            ////-----
            ///

            var user = _dbContex.User.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();
            //var user = _dbContex.User.Where(x => x.Email == Email && x.Password==Password).FirstOrDefault();
            if (user != null)
            {
                var roles = _dbContex.RoleMapper.Where(x => x.UserId == user.UserId).Select(x => new Role
                {
                    RoleName = x.Role.RoleName,
                    RoleId = x.Role.RoleId,
                }).OrderBy(x => x.RoleId).ToList();

                var loginDetailes = new UserVM
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    Password = user.Password,
                    Roles = roles,
                };

                return loginDetailes;
            }
            throw new UnauthorizedAccessException();

        }

        public Task<UserVM> GetResellerAdmin(string Email, string Password)
        {
            var resellerAdmin = _dbContex.ResellerAdminUsers.Where(x => x.CompanySupportEmail == Email && x.Password == Password).FirstOrDefault();
            if (resellerAdmin != null)
            {
                 var roles = new List<Role>{
                    new Role
                    {
                        RoleName = "Reseller Admin",
                        RoleId = 2
                    }
                 };
                var loginDetailes = new UserVM
                {
                    UserId = resellerAdmin.ResellerAdminUserId,
                    Email = resellerAdmin.CompanySupportEmail,
                    Password = resellerAdmin.Password,
                    Roles = roles,
                };

                return Task.FromResult(loginDetailes);

            }
            throw new UnauthorizedAccessException();
        }


        public Task<UserVM> GetOrganizationAdmin(string Email, string Password)
        {
            var OrganizationAdmin = _dbContex.OrganizationAdmins.Where(x => x.OrgAdminEmail == Email && x.OrgAdminPassword == Password).FirstOrDefault();
            if (OrganizationAdmin != null)
            {
                var roles = new List<Role>{
                    new Role
                    {
                        RoleName = "Organization Admin",
                        RoleId = 3
                    }
                 };
                var loginDetailes = new UserVM
                {
                    UserId = OrganizationAdmin.OrgID,
                    Email = OrganizationAdmin.OrgAdminEmail,
                    Password = OrganizationAdmin.OrgAdminPassword,
                    Roles = roles,
                };

                return Task.FromResult(loginDetailes);

            }
            throw new UnauthorizedAccessException();
        }
    }
}
