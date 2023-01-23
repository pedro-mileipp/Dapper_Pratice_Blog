using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository
    {
        private readonly SqlConnection _connection;

        // Construtor
        public UserRepository(SqlConnection connection)
            => _connection = connection;
        
        public IEnumerable<User> Get()
            => _connection.GetAll<User>();  // quando o metodo tem apenas uma linha pode-se usar o Expression Bodied Member 
        

        public User GetById(int id)
            => _connection.Get<User>(id);  
        

        public void Create(User user, string connectionString)
            => _connection.Insert<User>(user);
        
    }
}
