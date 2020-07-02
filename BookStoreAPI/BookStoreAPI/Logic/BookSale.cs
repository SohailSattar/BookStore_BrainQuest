using BookStoreAPI.Interfaces;
using BookStoreAPI.Mappings;
using BookStoreAPI.Models;
using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace BookStoreAPI.Logic
{
    public class BookSale : IBookSale, IRetriever, IAdd, IUpdate, IDelete
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public int Quantity { get; set; }
        public DateTime SoldOn { get; set; }

        public bool Add(ICRUDableEntity Entity)
        {
            var mapper = BookSaleMap.InitializeMapper();
            var bookSaleDTO = mapper.Map<Models.BookSales>(Entity);

            using (var context = new BookStoreContext())
            {
                context.BookSales.Add(bookSaleDTO);
                context.SaveChanges();
            }

            return true;
        }

        public bool Delete(int ID)
        {
            using (var context = new BookStoreContext())
            {
                var bookSalesList = context.BookSales.SingleOrDefault(b => b.SaleId == ID);

                context.BookSales.Remove(bookSalesList);
                context.SaveChanges();
            }
            return true;
        }

        public string Get(int ID)
        {
            string booksales = "";
            using (var context = new BookStoreContext())
            {
                var bookSalesList = context.BookSales.Where(b => b.SaleId == ID).Select(b => new { b.Book.BookName, b.Quantity, b.SoldOn });
                booksales = JsonConvert.SerializeObject(bookSalesList);
            }

            return booksales;
        }

        public string Get()
        {
            string booksales = "";
            using (var context = new BookStoreContext())
            {
                var bookSalesList = context.BookSales.Select(b => new { b.Book.BookName, b.Quantity, b.SoldOn });
                booksales = JsonConvert.SerializeObject(bookSalesList);
            }

            return booksales;
        }

        public bool Update(int ID, ICRUDableEntity Entity)
        {
            var mapper = BookSaleMap.InitializeMapper();
            var bookSaleDTO = mapper.Map<Models.BookSales>(Entity);

            bookSaleDTO.SaleId = ID;

            using (var context = new BookStoreContext())
            {
                context.BookSales.Update(bookSaleDTO);
                context.SaveChanges();
            }

            return true;
        }
    }

    //Validator class to validate the mandatory fields.

    public class BookSaleValidator : AbstractValidator<BookSale>
    {
        public BookSaleValidator()
        {
            RuleFor(x => x.Quantity).NotNull().WithMessage("Books quantity should be defined").InclusiveBetween(1, 50).WithMessage("Quantity should be between 1 to 50.");
        }
    }
}
