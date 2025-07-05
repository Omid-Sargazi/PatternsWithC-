namespace DesignPattern.ThreadConcept
{
    public class Problem10
    {
        public static void Increament()
        {
            int counter=0;

            for(int i=0; i<=1000; i++)
            {
                counter++;
            }

            Console.WriteLine($"Counter:{counter}");
        }

    }
}