namespace DesignPattern.Tasks
{
    public class RestaurantTasks
    {
        public static async Task MakeFood()
        {
            Console.WriteLine("foods is ordering..");
            Task piza = Task.Run(() => MakePizza());
            Task pasta = Task.Run(() => MakePasts());
            await Task.WhenAll(piza, pasta);

            Console.WriteLine("all foods are ready");
        }

        private static async Task MakePizza()
        {
            await Task.Delay(2000);
            Console.WriteLine("Pizza is done");
        }

        private static async Task MakePasts()
        {
            await Task.Delay(1000);
            Console.WriteLine("Pasta is done");
        }
    }
}