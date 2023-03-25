namespace BooksManager.Infrastructure.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        // Relacionamento com livros
        public List<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
        }
        public Author(int id, string firstName, string lastName, string email, DateTime birthDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            Books = new List<Book>(); // Inicializa a propriedade Books como uma lista vazia
        }
    }
}
