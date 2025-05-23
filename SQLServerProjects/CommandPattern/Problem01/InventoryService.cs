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


}