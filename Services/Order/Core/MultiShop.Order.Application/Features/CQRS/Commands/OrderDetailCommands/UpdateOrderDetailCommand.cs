namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class UpdateOrderDetailCommand
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderingId { get; set; }
    }
}
