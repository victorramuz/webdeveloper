using System;
using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;
using Projeto.Entities;
using Projeto.Repository.Contracts;
using System.Linq;

namespace Projeto.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        //atributo
        private readonly string connectionString;

        //construtor para injeção de dependência
        public ClienteRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(Cliente cliente)
        {
            var query = "INSERT INTO CLIENTE(NOME, EMAIL, DATACRIACAO) "
                      + "VALUES(@Nome, @Email, GETDATE())";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, cliente);
            }
        }

        public void Update(Cliente cliente)
        {
            var query = "UPDATE CLIENTE SET NOME = @Nome, EMAIL = @Email "
                      + "WHERE IdCliente = @IdCliente";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, cliente);
            }
        }

        public void Remove(Cliente cliente)
        {
            var query = "DELETE FROM CLIENTE WHERE IDCLIENTE = @IdCliente";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, cliente);
            }
        }

        public List<Cliente> SelectAll()
        {
            var query = "SELECT * FROM CLIENTE";

            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Query<Cliente>(query).ToList();
            }
        }

        public Cliente SelectById(int idCliente)
        {
            var query = "SELECT * FROM CLIENTE WHERE IDCLIENTE = @IdCliente";

            using (var conn = new SqlConnection(connectionString))
            {
                return conn.QuerySingleOrDefault(query, new { idCliente });
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this); //destrutor
        }
    }
}
