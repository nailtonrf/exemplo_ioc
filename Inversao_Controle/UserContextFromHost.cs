using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inversao_Controle
{
    /// <summary>
    /// Camada fora do domíno somente realize a interface core (cross cutting).
    /// </summary>
    public sealed class UserContextFromHost : IUserContext
    {
        public Guid Id { get; }
        public string Nome { get; }

        public UserContextFromHost(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}