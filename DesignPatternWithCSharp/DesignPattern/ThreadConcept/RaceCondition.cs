namespace DesignPattern.ThreadConcept
{
    public class Problem10
    {
       public object _lock = new object();
            public int counter=0;
        public void Increament()
        {

            for(int i=0; i<=1000; i++)
            {
               lock (_lock)
               {
                     counter++;
               }
            }

            Console.WriteLine($"Counter:{counter}");
        }

    }
}