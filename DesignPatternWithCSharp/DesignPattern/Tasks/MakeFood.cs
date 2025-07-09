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


        public static async Task MakeFoodRegularly()
        {
            Console.WriteLine("start");
            Task t1 = Task.Run(() => CookFood("A1", 1));
            Task t2 = Task.Run(() => CookFood("A2", 2));
            Task t3 = Task.Run(() => CookFood("A3", 3));
            Task t4 = Task.Run(() => CookFood("A4", 3));
            Task t5 = Task.Run(() => CookFood("A5", 2));
            Task t6 = Task.Run(() => CookFood("A6", 1));
            Task t7 = Task.Run(() => CookFood("A7", 1));
            Task t8 = Task.Run(() => CookFood("A8", 1));
            Task t9 = Task.Run(() => CookFood("A9", 1));
            Task t10 = Task.Run(() => CookFood("A10", 1));
            Task t11 = Task.Run(() => CookFood("A11", 1));
            await Task.WhenAll(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
        }

        private static async Task CookFood(string nameFood, int second)
        {
            Console.WriteLine($"{nameFood} is reading....");
            await Task.Delay(second * 1000);
            Console.WriteLine($"{nameFood} is done");
        }
    }
}