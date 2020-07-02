using BookStoreAPI.Interfaces;
using BookStoreAPI.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly ILogger<AuthorController> _logger;

        public AuthorController(ILogger<AuthorController> logger)
        {
            _logger = logger;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public string Get()
        {
            try
            {
                IRetriever authorsDetails = new Author();
                return authorsDetails.Get();
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("AuthorController => GET   Error Occured at: {0}{1}Error Details: {2}", DateTime.Now, Environment.NewLine, ex.InnerException.Message));
                return "";
            }
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                IRetriever authorDetails = new Author();
                return authorDetails.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("AuthorController => GET   Error Occured at: {0}{1}Error Details: {2}", DateTime.Now, Environment.NewLine, ex.InnerException.Message));
                return "";
            }

        }

        // POST api/<AuthorController>
        [HttpPost]
        public void Post([FromBody] Author author)
        {
            try
            {
                IAdd authorDetail = new Author();
                authorDetail.Add(author);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("AuthorController => POST   Error Occured at: {0}{1}Error Details: {2}", DateTime.Now, Environment.NewLine, ex.InnerException.Message));
            }
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Author author)
        {
            try
            {
                IUpdate authorDetails = new Author();
                authorDetails.Update(id, author);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("AuthorController => PUT   Error Occured at: {0}{1}Error Details: {2}", DateTime.Now, Environment.NewLine, ex.InnerException.Message));
            }
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                IDelete authorDetail = new Author();
                authorDetail.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("AuthorController => DELETE   Error Occured at: {0}{1}Error Details: {2}", DateTime.Now, Environment.NewLine, ex.InnerException.Message));
            }
        }
    }
}
