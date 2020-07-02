using System;

namespace BookStoreAPI.Interfaces
{
    public interface IBook : ICRUDableEntity
    {
        public string BookName { get; set; }
        public int AuthorID { get; set; }
        public int Pages { get; set; }
        public double Price { get; set; }
        public string ISBN { get; set; }
        public DateTime? PublishedOn { get; set; }
    }
}
