using System;
using System.Collections.Generic;

namespace BookStoreAPI.Models
{
    public partial class Books
    {
        public Books()
        {
            BookSales = new HashSet<BookSales>();
        }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public int AuthorId { get; set; }
        public int Pages { get; set; }
        public decimal Price { get; set; }
        public string Isbn { get; set; }
        public DateTime? PublishedOn { get; set; }

        public virtual Authors Author { get; set; }
        public virtual ICollection<BookSales> BookSales { get; set; }
    }
}
