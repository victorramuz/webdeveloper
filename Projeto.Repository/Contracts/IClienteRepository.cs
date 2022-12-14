using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Entities;

namespace Projeto.Repository.Contracts
{
    public interface IClienteRepository : IDisposable
    {
        void Create(Cliente cliente);
        void Update(Cliente cliente);
        void Remove(Cliente cliente);

        List<Cliente> SelectAll();
        Cliente SelectById(int idCliente);
    }
}
