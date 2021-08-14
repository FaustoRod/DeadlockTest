using AutoMapper;
using DeadlockTest.Business.Interfaces;
using DeadlockTest.Data.Contexts;
using DeadlockTest.Data.Models;

namespace DeadlockTest.Business.Services
{
    public class OrderService : BaseService<Order,DeadlockDbContext>, IOrderService
    {
        public OrderService(DeadlockDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
