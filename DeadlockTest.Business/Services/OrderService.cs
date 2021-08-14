using AutoMapper;
using DeadlockTest.Business.Interfaces;
using DeadlockTest.Data.Contexts;
using DeadlockTest.Data.Dto.Item;
using DeadlockTest.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeadlockTest.Business.Services
{
    public class OrderService : BaseService<Order, DeadlockDbContext>, IOrderService
    {
        private readonly DeadlockDbContext _context;
        private readonly IItemOrderService _itemOrderService;

        public OrderService(DeadlockDbContext context, IMapper mapper, IItemOrderService itemOrderService) : base(context, mapper)
        {
            _context = context;
            _itemOrderService = itemOrderService;
        }

        public async Task<bool> AddItem(ItemOrderDto itemOrder)
        {
            return await _itemOrderService.Create<ItemOrderDto>(itemOrder);
        }

        public async Task<string> CreateOrder()
        {
            var order = new Order
            {
                Code = Guid.NewGuid().ToString()
            };
            var result = await base.Create(order);
            if (result)
            {
                return order.Code;
            }
            return "";
        }

        public async Task<bool> RemoveItem(ItemOrderDto itemOrder)
        {
            var item = await _itemOrderService.GetBySingle(x => x.ItemId.Equals(itemOrder.ItemId) && x.OrderId.Equals(itemOrder.OrderId));
            if (item != null)
            {
                _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }

            return false;
        }

    }
}
