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
    public class BookSaleController : ControllerBase
    {
        private readonly ILogger<BookSaleController> _logger;

        public BookSaleController(ILogger<BookSaleController> logger)
        {
            _logger = logger;
        }

        // GET: api/<BookSaleController>
        [HttpGet]
        public string Get()
        {
            try
            {
                IRetriever booksSalesDetails = new BookSale();
                return booksSalesDetails.Get();
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("BookSaleController => GET   Error Occured at: {0}{1}Error Details: {2}", DateTime.Now, Environment.NewLine, ex.InnerException.Message));
                return "";
            }
        }

        // GET api/<BookSaleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                IRetriever booksSalesDetails = new BookSale();
                return booksSalesDetails.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("BookSaleController => GET  Error Occured at: {0}{1}Error Details: {2}", DateTime.Now, Environment.NewLine, ex.InnerException.Message));
                return "";
            }
        }

        // POST api/<BookSaleController>
        [HttpPost]
        public void Post([FromBody] BookSale bookSale)
        {
            try
            {
                IAdd bookSaleDetail = new BookSale();
                bookSaleDetail.Add(bookSale);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("BookSaleController => POST   Error Occured at: {0}{1}Error Details: {2}", DateTime.Now, Environment.NewLine, ex.InnerException.Message));
            }
        }

        // PUT api/<BookSaleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BookSale bookSale)
        {
            try
            {
                IUpdate bookSaleDetail = new BookSale();
                bookSaleDetail.Update(id, bookSale);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("BookSaleController => PUT   Error Occured at: {0}{1}Error Details: {2}", DateTime.Now, Environment.NewLine, ex.InnerException.Message));
            }
        }

        // DELETE api/<BookSaleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                IDelete bookSaleDetail = new BookSale();
                bookSaleDetail.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("BookSaleController => DELETE   Error Occured at: {0}{1}Error Details: {2}", DateTime.Now, Environment.NewLine, ex.InnerException.Message));
            }
        }
    }
}
