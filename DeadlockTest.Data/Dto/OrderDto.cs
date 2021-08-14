using DeadlockTest.Data.Models;
using System.Collections.Generic;

namespace DeadlockTest.Data.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}
