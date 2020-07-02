using BookStoreAPI.Interfaces;
using BookStoreAPI.Mappings;
using BookStoreAPI.Models;
using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace BookStoreAPI.Logic
{
    public class Book : IBook, IRetriever, IAdd, IUpdate, IDelete
    {
        // Properties
        public int ID { get; set; }
        public string BookName { get; set; }
        public int AuthorID { get; set; }
        public int Pages { get; set; }
        public double Price { get; set; }
        public string ISBN { get; set; }
        public DateTime? PublishedOn { get; set; }

        public bool Add(ICRUDableEntity Entity)
        {
            var mapper = BookMap.InitializeMapper();
            var bookDTO = mapper.Map<Models.Books>(Entity);

            using (var context = new BookStoreContext())
            {
                context.Books.Add(bookDTO);
                context.SaveChanges();
            }

            return true;
        }

        public bool Delete(int ID)
        {
            using (var context = new BookStoreContext())
            {
                var bookList = context.Books.SingleOrDefault(b => b.BookId == ID);

                context.Books.Remove(bookList);
                context.SaveChanges();
            }
            return true;
        }

        public string Get(int ID)
        {
            string books = "";
            using (var context = new BookStoreContext())
            {
                var booksList = context.Books.Where(b => b.BookId == ID).Select(b => new { b.BookName, Author = string.Join(" ", b.Author.FirstName + b.Author.LastName), b.Pages, b.Price, b.Isbn, b.PublishedOn });
                books = JsonConvert.SerializeObject(booksList);
            }

            return books;
        }

        public string Get()
        {
            string books = "";
            using (var context = new BookStoreContext())
            {
                var booksList = context.Books.Select(b => new { b.BookName, Author = string.Join(" ", b.Author.FirstName + b.Author.LastName), b.Pages, b.Price, b.Isbn, b.PublishedOn });
                books = JsonConvert.SerializeObject(booksList);
            }

            return books;
        }

        public bool Update(int ID, ICRUDableEntity Entity)
        {
            var mapper = BookMap.InitializeMapper();
            var bookDTO = mapper.Map<Models.Books>(Entity);

            bookDTO.BookId = ID;

            using (var context = new BookStoreContext())
            {
                context.Books.Update(bookDTO);
                context.SaveChanges();
            }

            return true;
        }
    }

    //Validator class to validate the mandatory fields.

    public class BookValidator : AbstractValidator<Book>
    {
        //ISBN format [Regular Expression]
        string regexISBN = @"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$";
        public BookValidator()
        {
            RuleFor(x => x.BookName).NotNull().WithMessage("Book name is not mentioned").Length(2, 250).WithMessage("First Name should be atleast 2 or more characters long");
            RuleFor(x => x.Price).NotNull().WithMessage("Price should be defined.").InclusiveBetween(0.01, 10000).WithMessage("The price should be between 0.01 to 10000");
            RuleFor(x => x.ISBN).NotNull().WithMessage("ISBN is not mentioned").Matches(regexISBN).WithMessage("Invalid ISBN number format. The format should be in XXX-X-XX-XXXXX");
            //RuleFor(x => x.LastName).NotNull().WithMessage("Last Name field shouldn't be empty").Length(3, 250).WithMessage("Last Name should be atleast 3 or more characters long");
        }
    }
}
