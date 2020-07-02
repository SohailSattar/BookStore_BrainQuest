namespace BookStoreAPI.Interfaces
{
    public interface IAuthor : ICRUDableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
