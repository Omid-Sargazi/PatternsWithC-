namespace AdvantureWorksDatabse02.CommandPattern
{
    public interface IOrderCommand
    {
        Task ExecuteAsync();
        Task UndoAsync();
        bool CanExecute();
        decimal CalculatePrice();
    }

    public class FoodOrderCommand : IOrderCommand
    {
        public decimal CalculatePrice()
        {
            throw new NotImplementedException();
        }

        public bool CanExecute()
        {
            throw new NotImplementedException();
        }

        public Task ExecuteAsync()
        {
            throw new NotImplementedException();
        }

        public Task UndoAsync()
        {
            throw new NotImplementedException();
        }
    }

    public class FoodItem
    {
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public List<string> SpecialRequests { get; } = new();
    }

    public class Kitchen
    {
        public bool IsOpen { get; set; } = true;
        public List<FoodItem> CurrentOrder = new();
        public async Task AddItem(FoodItem item)
        {
            CurrentOrder.Add(item);
            await Task.Delay(100);
        }

        public async Task RemoveItem(FoodItem item)
        {
            CurrentOrder.Remove(item);
            await Task.Delay(100);
        }
    }
}