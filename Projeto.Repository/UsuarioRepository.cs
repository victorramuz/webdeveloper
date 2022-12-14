using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient; //importando
using Dapper; //importando
using Projeto.Entities; //importando
using Projeto.Repository.Contracts; //importando

namespace Projeto.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //atributo
        private readonly string connectionString;

        //construtor para injeção de dependência
        public UsuarioRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(Usuario usuario)
        {
            var query = "INSERT INTO USUARIO(NOME, USERNAME, PASSWORD) "
                      + "VALUES(@Nome, @Username, @Password)";

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Execute(query, usuario);
            }
        }

        public Usuario Find(string username, string password)
        {
            var query = "SELECT * FROM USUARIO "
                      + "WHERE USERNAME = @Username AND PASSWORD = @Password";

            using (var conn = new SqlConnection(connectionString))
            {
                return conn.QuerySingleOrDefault<Usuario>(query, 
                    new { Username = username, Password = password });
            }
        }

        public bool HasUsername(string username)
        {
            var query = "SELECT COUNT(USERNAME) FROM USUARIO "
                      + "WHERE USERNAME = @Username";

            using (var conn = new SqlConnection(connectionString))
            {
                return conn.QuerySingleOrDefault<int>(query,
                    new { Username = username }) > 0;
            }
        }
    }
}
