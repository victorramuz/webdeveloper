using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Entities; //importando

namespace Projeto.Repository.Contracts
{
    public interface IUsuarioRepository
    {
        void Create(Usuario usuario);
        Usuario Find(string username, string password);
        bool HasUsername(string username);
    }
}
