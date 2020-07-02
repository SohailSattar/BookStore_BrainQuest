using AutoMapper;
using BookStoreAPI.Logic;

namespace BookStoreAPI.Mappings
{
    public class BookMap
    {
        public static Mapper InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, Models.Books>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
