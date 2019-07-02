using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Blog.BusinessLogicLayer.DataTransferObjects;

namespace Blog.BusinessLogicLayer.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<ClaimsIdentity> Authenticate(UserDataTransferObject userDto);
        Task SetInitialData(UserDataTransferObject adminDto, List<string> roles);
    }
}