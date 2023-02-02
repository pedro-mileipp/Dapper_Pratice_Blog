using System;
using Microsoft.Data.SqlClient;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Dapper;
using Blog.Repositories;

namespace Blog{
    class Program{
        private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$; Trusted_Connection=False; TrustServerCertificate=True";
        static void Main(){
            var connection = new SqlConnection(CONNECTION_STRING);
            using(connection){
                ReadUsers(connection);
                System.Console.WriteLine();
                ReadRoles(connection);
            }
        }

        public static void ReadUsers(SqlConnection connection){
            
            var repository = new UserRepository(connection);
            var users = repository.Get();   

            foreach(var user in users){
                Console.WriteLine(user.Name);
            }     
        }
        public static void ReadRoles(SqlConnection connection){
            
            var repository = new RoleRepository(connection);
            var roles = repository.Get();   

            foreach(var role in roles){
                Console.WriteLine(role.Name);
            }     
        }
    
        
    

    }
}