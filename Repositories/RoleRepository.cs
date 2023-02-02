using Microsoft.Data.SqlClient;
using Dapper.Contrib.Extensions;
using Blog.Models;
using System.Collections.Generic;


namespace Blog.Repositories
{
    public class RoleRepository
    {
        private readonly SqlConnection _connection;

        // Construtor
        public RoleRepository(SqlConnection connection)
            => _connection = connection;
        
        public IEnumerable<Role> Get()
            => _connection.GetAll<Role>();  // quando o metodo tem apenas uma linha pode-se usar o Expression Bodied Member 
        

        public Role GetById(int id)
            => _connection.Get<Role>(id);  
        

        public void Create(Role role, string connectionString)
            => _connection.Insert<Role>(role);
    }
}