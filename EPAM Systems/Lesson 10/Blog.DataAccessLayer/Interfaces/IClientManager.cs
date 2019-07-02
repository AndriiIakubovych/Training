using System;
using Blog.DataAccessLayer.Entities;

namespace Blog.DataAccessLayer.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}