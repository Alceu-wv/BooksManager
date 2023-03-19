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
    }
}
