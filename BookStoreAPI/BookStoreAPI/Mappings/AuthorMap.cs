using AutoMapper;
using BookStoreAPI.Logic;

namespace BookStoreAPI.Mappings
{
    public class AuthorMap
    {
        public static Mapper InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Author, Models.Authors>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
