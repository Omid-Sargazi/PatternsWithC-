namespace AdvantureWorksDatabse02.Delegate
{
    public class PersonInDelegate
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class PersonProcessor
    {
        public delegate bool FIlter(PersonInDelegate p);
        public void PrintFiltered(List<PersonInDelegate> people, FIlter filter)
        {
            foreach (var person in people)
            {
                if (filter(person))
                {
                    Console.WriteLine($"{person.Name}, {person.Age}");
                }
            }
        }
    }
}