using Microsoft.Data.SqlClient;
using Blog.Models;
using Blog.Repositories;

namespace Blog{
    class Program{
        private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$; Trusted_Connection=False; TrustServerCertificate=True";
        static void Main(){
            var connection = new SqlConnection(CONNECTION_STRING);
            using(connection){
                ReadUsers(connection);
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                ReadRoles(connection);
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                ReadTags(connection);
            }
        }

        public static void ReadUsers(SqlConnection connection){
            
            var repository = new Repository<User>(connection);
            var items = repository.Get();   

            foreach(var item in items){
                Console.WriteLine(item.Name);
                foreach(var role in  item.Roles){
                    Console.WriteLine($" - {role.Name}");
                }
            }     
        }
        public static void ReadRoles(SqlConnection connection){
            
            var repository = new Repository<Role>(connection);
            var items = repository.Get();   

            foreach(var item in items){
                Console.WriteLine(item.Name);
            }      
        }
        public static void ReadTags(SqlConnection connection){
            
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();   

            foreach(var item in items){
                Console.WriteLine(item.Name);
            }      
        }

    }
}