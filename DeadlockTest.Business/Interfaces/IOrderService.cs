using DeadlockTest.Data.Dto.Item;
using DeadlockTest.Data.Models;
using System.Threading.Tasks;

namespace DeadlockTest.Business.Interfaces
{
    public interface IOrderService:IBaseService<Order>
    {
        Task<string> CreateOrder();
        Task<bool> AddItem(ItemOrderDto itemOrder);
        Task<bool> RemoveItem(ItemOrderDto itemOrder);
    }
}
