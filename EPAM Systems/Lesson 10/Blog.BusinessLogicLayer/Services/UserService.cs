using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Blog.DataAccessLayer.Entities;
using Blog.DataAccessLayer.Interfaces;
using Blog.BusinessLogicLayer.DataTransferObjects;
using Blog.BusinessLogicLayer.Interfaces;
using Blog.BusinessLogicLayer.Infrastructure;

namespace Blog.BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork database)
        {
            Database = database;
        }

        public async Task<OperationDetails> Create(UserDataTransferObject userDto)
        {
            BlogUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            ClientProfile clientProfile;
            IdentityResult result;
            if (user == null)
            {
                user = new BlogUser { UserName = userDto.UserName, Email = userDto.Email };
                result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                clientProfile = new ClientProfile { UserId = user.Id };
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Registration has been successfully completed!", "");
            }
            else
                return new OperationDetails(false, "User with this login already exists!", "Email");
        }

        public async Task<ClaimsIdentity> Authenticate(UserDataTransferObject userDto)
        {
            ClaimsIdentity claim = null;
            BlogUser user = await Database.UserManager.FindAsync(userDto.UserName, userDto.Password);
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task SetInitialData(UserDataTransferObject adminDto, List<string> roles)
        {
            BlogRole role;
            foreach (string roleName in roles)
            {
                role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new BlogRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}