namespace DesignPattern.Delegate
{

    public class Usserr
    {
         public string Name {get;set;}
        
        public int Age {get;set;}
    }

    
    public class UserDelagate
    {
        public delegate void PrintUser(Usserr user);

        public static void PrintUsers(List<Usserr> users, PrintUser printMethod)
        {
            foreach (var user in users)
            {
                printMethod(user);
            }
        }
    }
}