using BookStoreAPI.Interfaces;
using BookStoreAPI.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }


        // GET: api/<BookController>
        [HttpGet]
        public string Get()
        {
            try
            {
                IRetriever booksDetails = new Book();
                return booksDetails.Get();
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("BookController => GET   Error Occured at: {0}{1}Error Details: {2}", DateTime.Now, Environment.NewLine, ex.InnerException.Message));
                return "";
            }
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                IRetriever bookDetails = new Book();
                return bookDetails.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("BookController => GET  Error Occured at: {0}{1}Error Details: {2}", DateTime.Now, Environment.NewLine, ex.InnerException.Message));
                return "";
            }
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] Book book)
        {
            try
            {
                IAdd bookDetail = new Book();
                bookDetail.Add(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("BookController => POST   Error Occured at: {0}{1}Error Details: {2}", DateTime.Now, Environment.NewLine, ex.InnerException.Message));
            }
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book book)
        {
            try
            {
                IUpdate bookDetail = new Book();
                bookDetail.Update(id, book);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("BookController => PUT   Error Occured at: {0}{1}Error Details: {2}", DateTime.Now, Environment.NewLine, ex.InnerException.Message));
            }
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                IDelete bookDetail = new Book();
                bookDetail.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("BookController => DELETE   Error Occured at: {0}{1}Error Details: {2}", DateTime.Now, Environment.NewLine, ex.InnerException.Message));
            }
        }
    }
}
