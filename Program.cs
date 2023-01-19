using System;
using Microsoft.Data.SqlClient;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Dapper;

namespace Blog{
    class Program{
        private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$; Trusted_Connection=False; TrustServerCertificate=True";
        static void Main(){

            /* CRUD */
            // CreateUser();
            // UpdateUser();
            // DeleteUser();
            // ReadUser();
            // ReadUsers();

            /*REPOSITORY PATTERN*/
            
        }

        public static void ReadUsers(){
            using(var connection = new SqlConnection(CONNECTION_STRING)){
                var users = connection.GetAll<User>(); // o método GetAll faz a sintaxe SQL para pegar as informações da tabela user    

                foreach(var user in users){
                    Console.WriteLine(user.Name);
                }

                /* FORMA ANÁLOGA ESCREVENDO A QUERY */
                // var listNames = connection.Query<User>("SELECT [Name] FROM [User]");
                // foreach(var user in listNames){
                //     Console.WriteLine(user.Name);
                // }  
            }
        }
        public static void ReadUser(){
            using(var connection = new SqlConnection(CONNECTION_STRING)){
                var user = connection.Get<User>(2); // O metódo Get pega especificamente 
                System.Console.WriteLine(user.Name);
            }
        }
        public static void CreateUser(){
            var user = new User(){
                Bio = "Irmão do Pedro",
                Email = "miguel@proton.com",
                Image = "https://",
                Name = "Miguel Mileipp",
                PasswordHash = "HASH",
                Slug = "miguel-mileipp"
            };
            using(var connection = new SqlConnection(CONNECTION_STRING)){
                connection.Insert<User>(user); 
                System.Console.WriteLine("Cadastro realizado com sucesso!");
            }

            /* FORMA ANÁLOGA ESCREVENDO A QUERY */
            // var user2 = new User(){
            //     Bio = "Irmã do Pedro",
            //     Email = "alice@proton.com",
            //     Image = "https://",
            //     Name = "Alice Mileipp",
            //     PasswordHash = "HASH",
            //     Slug = "alice-mileipp"
            // };
            
            // var insertSql = "INSERT INTO [User] VALUES(@Name, @Email, @PasswordHash, @Bio, @Image, @Slug)";
            // var connection = new SqlConnection(CONNECTION_STRING);
            // var rows = connection.Execute(insertSql, new
            // {
            //     user2.Bio,
            //     user2.Email,
            //     user2.Image,
            //     user2.Name,
            //     user2.PasswordHash,
            //     user2.Slug
            // });
        
            // Console.WriteLine($"{rows} linhas inseridas");
        }
        public static void UpdateUser(){
            var user = new User(){
                Id = 1002,
                Bio = "Random",
                Email = "jhonny_walker@proton.com",
                Image = "https://",
                Name = "Jhonny Walker",
                PasswordHash = "HASH",
                Slug = "jhonny-walker"
            };
            using(var connection = new SqlConnection(CONNECTION_STRING)){
                connection.Update<User>(user);
                System.Console.WriteLine("Usuário atualizado com sucesso!");
            }

            /* FORMA ANÁLOGA ESCREVENDO A QUERY */
            // var connection2 = new SqlConnection(CONNECTION_STRING);
            // var updateQuery = "UPDATE [User] SET [Name] = @Name, [Bio] = @Bio, [Email] = @Email, [Slug] = @Slug WHERE [Id] = 1003";
            // var rows = connection2.Execute(updateQuery, new {
            //     Name = "Loren Watch",
            //     Bio = "Random",
            //     Email = "lorenwatch@hotmail.com",
            //     Slug = "loren-watch"
            // });
            // Console.WriteLine($"{rows} linhas afetadas");
        }
        public static void DeleteUser(){
             using(var connection = new SqlConnection(CONNECTION_STRING)){
                var user = connection.Get<User>(2); 
                connection.Delete<User>(user);
                Console.WriteLine("User deletado com sucesso!");
            }
            
            /* FORMA ANÁLOGA ESCREVENDO A QUERY */
            // var connection2 = new SqlConnection(CONNECTION_STRING);
            // var deleteQuery = "DELETE FROM [User] WHERE [Id] = @Id";
            // var rows = connection2.Execute(deleteQuery, new{
            //     Id = 1
            // });
        }
    

    }
}