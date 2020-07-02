using System;

namespace BookStoreAPI.Models
{
    public partial class BookSales
    {
        public long SaleId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

        private DateTime soldOn;
        public DateTime SoldOn {
            get { return soldOn; }
            set { soldOn = DateTime.Now; }
        }

        public virtual Books Book { get; set; }
    }
}
