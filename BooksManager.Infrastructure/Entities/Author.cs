﻿namespace BooksManager.Infrastructure.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public byte[] Photo { get; set; }

        // Relacionamento com livros
        public List<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
        }
        public Author(int id, string firstName, string lastName, string email, DateTime birthDate, byte[] photo)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            Photo = photo;
            Books = new List<Book>(); // Inicializa a propriedade Books como uma lista vazia
        }
    }
}
