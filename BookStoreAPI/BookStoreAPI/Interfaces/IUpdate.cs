namespace BookStoreAPI.Interfaces
{
    public interface IUpdate
    {
        public bool Update(int ID, ICRUDableEntity Entity);
    }
}
