namespace BooksManager.Infrastructure.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }

        // Relacionamento com autores
        public List<Author> Authors { get; set; }
    }
}
