using AutoMapper;
using DeadlockTest.Data.Dto.Item;
using DeadlockTest.Data.Models;

namespace DeadlockTest.Data.Profiles
{
    public class ItemProfile:Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<OrderItem, ItemOrderDto>().ReverseMap();
        }
    }
}
