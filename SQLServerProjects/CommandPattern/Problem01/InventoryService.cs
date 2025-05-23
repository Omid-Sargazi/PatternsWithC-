namespace CommandPattern.Problem01
{
    public interface ICommandInventory
    {
        Task ExecuteAsync();
        Task UndoAsync();
    }
    public class InventoryService
    {
        private Dictionary<string, int> _inventory = new Dictionary<string, int>();
        public Task UpdateInventoryAsync(string productId, int quantity)
        {
            if (_inventory.ContainsKey(productId))
                _inventory[productId] -= quantity;
            else
                _inventory[productId] = quantity;
            Console.WriteLine($"Inventory updated: {productId}, Remaining: {_inventory[productId]}");
            return Task.CompletedTask;
        }

        public Task RestoreInventoryAsync(string productId, int quantity)
        {
            _inventory[productId] += quantity;
            Console.WriteLine($"Inventory restored: {productId}, Remaining: {_inventory[productId]}");
            return Task.CompletedTask;
        }

    }

    public class OrderService
    {
        public Task CreateOrderAsync(string orderId, string productId, int quantity)
        {
            Console.WriteLine($"Order created: {orderId} for {productId} (Quantity: {quantity})");
            return Task.CompletedTask;
        }

        public Task CancelOrderAsync(string orderId)
        {
            Console.WriteLine($"Order cancelled: {orderId}");
            return Task.CompletedTask;
        }

        public class NotificationService
        {
            public Task SendNotificationAsync(string message)
            {
                Console.WriteLine($"Notification sent: {message}");
                return Task.CompletedTask;
            }
        }


        public class CreateOrderCommand : ICommandInventory
        {
            private readonly OrderService _orderService;
            private readonly InventoryService _inventoryService;
            private readonly NotificationService _notificationService;
            private readonly string _orderId;
            private readonly string _productId;
            private readonly int _quantity;

            public CreateOrderCommand(OrderService orderService, InventoryService inventoryService,
                                    NotificationService notificationService, string orderId, string productId, int quantity)
            {
                _orderService = orderService;
                _inventoryService = inventoryService;
                _notificationService = notificationService;
                _orderId = orderId;
                _productId = productId;
                _quantity = quantity;
            }
            public async Task ExecuteAsync()
            {
                await _orderService.CreateOrderAsync(_orderId, _productId, _quantity);
                await _inventoryService.UpdateInventoryAsync(_orderId, _quantity);
                await _notificationService.SendNotificationAsync($"Order {_orderId} created successfully.");
            }

            public async Task UndoAsync()
            {
                await _orderService.CancelOrderAsync(_orderId);
                await _inventoryService.RestoreInventoryAsync(_productId, _quantity);
                await _notificationService.SendNotificationAsync($"Order {_orderId} cancelled.");
            }
        }

        public class OrderProcessor
        {
            private readonly Stack<ICommandInventory> _commandHistory = new Stack<ICommandInventory>();
            public async Task ExecuteCommandAsync(ICommandInventory command)
            {
                await command.ExecuteAsync();
                _commandHistory.Push(command);
            }
        public async Task UndoLastCommandAsync()
        {
            if (_commandHistory.Count > 0)
            {
                var command = _commandHistory.Pop();
                await command.UndoAsync();
            }
        }
        }

    }


}