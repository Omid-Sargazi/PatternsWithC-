namespace DesignPattern.Delegate
{
    public class UserDelagate
    {
        public delegate void PrintUser(UserDelagate user);

        public string Name {get;set;}
        
        public int Age {get;set;}


        public static void PrintUsers(List<User> users, PrintUser printMethod)
        {
            foreach (var user in users)
            {
                printMethod(user);
            }
        }
    }
}