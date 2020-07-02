using BookStoreAPI.Interfaces;
using BookStoreAPI.Mappings;
using BookStoreAPI.Models;
using FluentValidation;
using Newtonsoft.Json;
using System.Linq;

namespace BookStoreAPI.Logic
{
    public class Author : IAuthor, IRetriever, IAdd, IUpdate, IDelete
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool Add(ICRUDableEntity Entity)
        {
            var mapper = AuthorMap.InitializeMapper();
            var authorDTO = mapper.Map<Models.Authors>(Entity);

            using (var context = new BookStoreContext())
            {
                context.Authors.Add(authorDTO);
                context.SaveChanges();
            }

            return true;
        }

        public bool Delete(int ID)
        {
            using (var context = new BookStoreContext())
            {
                var authorsList = context.Authors.SingleOrDefault(a => a.AuthorId == ID);

                context.Authors.Remove(authorsList);
                context.SaveChanges();
            }
            return true;
        }

        public string Get(int ID)
        {
            string author = "";
            using (var context = new BookStoreContext())
            {
                var authorsList = context.Authors.Where(a => a.AuthorId == ID).Select(a => new { a.AuthorId, a.FirstName, a.LastName });
                author = JsonConvert.SerializeObject(authorsList);
            }

            return author;
        }

        public string Get()
        {
            string authors = "";
            using (var context = new BookStoreContext())
            {
                var authorsList = context.Authors.Select(a => new { a.AuthorId, a.FirstName, a.LastName });
                authors = JsonConvert.SerializeObject(authorsList);
            }

            return authors;
        }

        public bool Update(int ID, ICRUDableEntity Entity)
        {
            var mapper = AuthorMap.InitializeMapper();
            var authorDTO = mapper.Map<Models.Authors>(Entity);

            authorDTO.AuthorId = ID;

            using (var context = new BookStoreContext())
            {
                context.Authors.Update(authorDTO);
                context.SaveChanges();
            }

            return true;
        }
    }


    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage("First Name field shouldn't be empty").Length(3, 250).WithMessage("First Name should be atleast 3 or more characters long");
            RuleFor(x => x.LastName).NotNull().WithMessage("Last Name field shouldn't be empty").Length(3, 250).WithMessage("Last Name should be atleast 3 or more characters long");
        }
    }
}
