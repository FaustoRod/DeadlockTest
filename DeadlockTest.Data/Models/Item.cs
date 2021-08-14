using System.Collections.Generic;

namespace DeadlockTest.Data.Models
{
    public class Item:BaseModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public virtual IList<OrderItem> OrderItems { get; set; }
    }
}
