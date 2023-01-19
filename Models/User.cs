using System;
using Dapper.Contrib.Extensions;

namespace Blog.Models
{

    // O Dapper.Contrib pluraliza por padrão o nome das entidades, para isso a solução é usar um meta-dado(informações adicionais que podem ser passadas para uma classe)
    [Table("[User]")] // Aqui é passado a instrução para buscar a entidade User e não Users. Lembrando que para os ORM cada classe é uma tabela e instância um registro.
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Bio { get; set; }
        public string? Image { get; set; }
        public string? Slug { get; set; }
    }
}