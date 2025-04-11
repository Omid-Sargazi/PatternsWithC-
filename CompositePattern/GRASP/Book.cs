namespace CompositePattern.GRASP
{
    public class Book 
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsBorrowed { get; set; }

        public void Borrow()
        {
            if(!IsBorrowed)
            {
                IsBorrowed = true;
                Console.WriteLine($"{Title} is now borrowed");
            }
            else{
                Console.WriteLine($"{Title} is already borrowed");
            }
        }

        public void Return()
        {
            if (IsBorrowed)
            {
                IsBorrowed = false;
                Console.WriteLine($"{Title} is returned");
            }
        }
    }
}