

namespace uintofwork.core.Models
{
   public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public Author author { get; set; }
        public int authorId { get; set; }

    }
}
