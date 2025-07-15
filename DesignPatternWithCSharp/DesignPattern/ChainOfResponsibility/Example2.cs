namespace DesignPattern.ChainOfResponsibility
{
    public abstract class ChainHandler
    {
        protected ChainHandler _next;
        public void setNext(ChainHandler next)
        {
            _next = next;
        }

        public abstract void Handle(string requestType);
    }

    public class Level1Handler : ChainHandler
    {
        public override void Handle(string requestType)
        {
            if (requestType == "General")
                Console.WriteLine("level1 will do it.");
            _next.Handle(requestType);
        }
    }

    public class Level2Handler : ChainHandler
    {
        public override void Handle(string requestType)
        {
            if (requestType == "level 2")
            {
                Console.WriteLine("Level2 will do it");
            }
            _next.Handle(requestType);
        }
    }

    public class Level3Handler : ChainHandler
    {
        public override void Handle(string requestType)
        {
            if (requestType == "level3")
                Console.WriteLine("Level3 will do it");
            Console.WriteLine("Unknown request. No handler could process it.");
        }
    }


    public class ClientChain
    {
        public static void HandleChain()
        {
            var leve1 = new Level1Handler();
            var leve12 = new Level2Handler();
            var level3 = new Level3Handler();

            leve1.setNext(leve12);
            leve12.setNext(level3);
            leve1.Handle("General");
            leve1.Handle("omid");
        }   
    }


}