namespace BookStoreAPI.Interfaces
{
    interface IRetriever
    {
        public string Get(int ID);

        public string Get();
    }
}
