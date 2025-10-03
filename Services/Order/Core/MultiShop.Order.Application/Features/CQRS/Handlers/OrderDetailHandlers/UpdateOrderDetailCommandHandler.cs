using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var value = await _repository.GetByIdAsync(updateOrderDetailCommand.OrderDetailId);
            value.Amount = updateOrderDetailCommand.Amount;
            value.ProductId = updateOrderDetailCommand.ProductId;
            value.Price = updateOrderDetailCommand.Price;
            value.TotalPrice = updateOrderDetailCommand.TotalPrice;
            value.Name = updateOrderDetailCommand.Name; 
            value.OrderingId = updateOrderDetailCommand.OrderingId;
            await _repository.UpdateAsync(value);
        }
    }
}
