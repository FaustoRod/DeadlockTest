namespace DeadlockTest.Data.Models
{
    public class OrderItem : BaseModel
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Amount { get; set; }
    }
}
