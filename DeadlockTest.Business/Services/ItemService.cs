using AutoMapper;
using DeadlockTest.Business.Interfaces;
using DeadlockTest.Data.Contexts;
using DeadlockTest.Data.Models;

namespace DeadlockTest.Business.Services
{
    public class ItemService : BaseService<Item, DeadlockDbContext>, IItemService
    {
        public ItemService(DeadlockDbContext context, IMapper mapper):base(context,mapper)
        {

        }
    }
}
