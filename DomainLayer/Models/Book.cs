namespace DomainLayer.Models
{
    public class BookModel
    {
        public int BookID { get; set; }

        public string Name { get; set; }

        public string AuthorName { get; set; }

        public string Department { get; set; }

        public bool IsActive { get; set; }
    }
}