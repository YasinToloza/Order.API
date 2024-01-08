using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Order.API.Data;

namespace Order.API.Repositories
{
    public class OrderRepository:RepositoryBase<Models.Order>, IOrderAsyncRepository
    {
        public OrderRepository(AppDbContext dbContext):base(dbContext) 
        { 
        }

        public async Task<IEnumerable<Models.Order>> GetOrderByUserName(string userName)
        {
            return await dbContext.orders.Where(o => o.UserName == userName).ToListAsync();
        }

        public async Task<int> UpdateAddress(Models.Order order)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", order.Id),
                new SqlParameter("@AddressLine", order.AddressLine),
                new SqlParameter("@Country", order.Country),
                new SqlParameter("@State", order.State),
                new SqlParameter("@ZipCode", order.ZipCode)
            };
            return await dbContext.Database
                .ExecuteSqlRawAsync("exec upd_Order_Address @Id,@AddressLine,@Country,@State,@ZipCode",
                parameters.ToArray());
        }
    }
}
