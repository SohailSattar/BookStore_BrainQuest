using System;

namespace BookStoreAPI.Interfaces
{
    public interface IBookSale : ICRUDableEntity
    {
        public int BookID { get; set; }
        public int Quantity { get; set; }
        public DateTime SoldOn { get; set; }
    }
}
