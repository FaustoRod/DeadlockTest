using AutoMapper;
using DeadlockTest.Business.Interfaces;
using DeadlockTest.Data.Contexts;
using DeadlockTest.Data.Models;

namespace DeadlockTest.Business.Services
{
    public class ItemOrderService:BaseService<OrderItem,DeadlockDbContext>, IItemOrderService

    {
        public ItemOrderService(DeadlockDbContext context, IMapper mapper):base(context,mapper)
        {

        }
    }
}
