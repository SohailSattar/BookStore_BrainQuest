using AutoMapper;
using BookStoreAPI.Logic;

namespace BookStoreAPI.Mappings
{
    public class BookSaleMap
    {
        public static Mapper InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookSale, Models.BookSales>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
