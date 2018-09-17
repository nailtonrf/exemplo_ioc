using System;

namespace Core
{
    public interface IUserContext
    {
        Guid Id { get; }
        string Nome { get; }
    }
}