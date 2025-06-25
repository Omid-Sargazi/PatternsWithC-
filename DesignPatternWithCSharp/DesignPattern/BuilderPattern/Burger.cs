namespace DesignPattern.BuilderPattern
{
    public class Burger
    {
        public string Bun { get; set; }
        public string Patty { get; set; }
        public string Cheese { get; set; }
        public List<string> Toppings { get; } = new List<string>();

        public void Display()
        {
            Console.WriteLine($"Burger with {Bun} bun,{Patty} patty");
            if (!string.IsNullOrEmpty(Cheese))
                Console.WriteLine($"+ {Cheese} cheese");
            if (Toppings.Count > 0)
                Console.WriteLine($"+ Toppings:{string.Join(",", Toppings)}");
        }
    }

    public interface IBurgerBuilder
    {
        void SetBun();
        void SetPatty();
        void SetCheese();
        void AddTopping();
        Burger GetBurger();
    }

    public class CheeseBurgerBuilder : IBurgerBuilder
    {
        private Burger _burger = new Burger();
        public void AddTopping()
        {
            _burger.Toppings.Add("Lettuce");
            _burger.Toppings.Add("Tomato");
            _burger.Toppings.Add("Onion");
        }

        public Burger GetBurger()
        {
            return _burger;
        }

        public void SetBun()
        {
            _burger.Bun = "Regular";
        }

        public void SetCheese()
        {

            _burger.Cheese = "American";
        }

        public void SetPatty()
        {
            _burger.Patty = "Beef";
        }
    }

    public class BurgerChef
    {
        private IBurgerBuilder _builder;
        public BurgerChef(IBurgerBuilder burger)
        {
            _builder = burger;
        }


        public void MakeBuilder()
        {
            _builder.SetBun();
            _builder.SetCheese();
            _builder.SetPatty();
            _builder.AddTopping();
        }
    }
}