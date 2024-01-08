namespace Order.API.Repositories
{
    public interface IOrderAsyncRepository:IAsyncRepository<Models.Order>
    {
        Task<IEnumerable<Models.Order>> GetOrderByUserName(string userName);
        Task<int> UpdateAddress(Models.Order order);
    }
}
