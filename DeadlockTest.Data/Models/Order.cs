using System.Collections.Generic;

namespace DeadlockTest.Data.Models
{
    public class Order : BaseModel
    {
        public string Code { get; set; }
        public virtual IList<OrderItem> OrderItems { get; set; }
        public virtual IList<Item> Items { get; set; }
    }
}
