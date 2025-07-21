namespace LeetCode.Delegate
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }

    public delegate bool UserRule(User user);
    public class UserValidator
    {
        private readonly List<UserRule> _rules = new();
        public UserValidator AddRule(UserRule rule)
        {
            _rules.Add(rule);
            return this;
        }

        public bool Valdate(User user)
        {
            foreach (var rule in _rules)
            {
                if (!rule(user))
                    Console.WriteLine("❌ Validation failed");
                return false;
            }
            Console.WriteLine("✅ Validation passed");
            return true;
        }
    }

    public class ValidateRule
    {
        public static void Run()
        {
            var user1 = new User { Username = "Ali", Email = "ali@example.com", Age = 25 };
            var user2 = new User { Username = "", Email = "no-at-symbol", Age = 17 };

            var validator = new UserValidator()
            .AddRule(u => !string.IsNullOrWhiteSpace(u.Username))
            .AddRule(u => u.Email.Contains("@"))
            .AddRule(u => u.Age >= 18);

            validator.Valdate(user1);
            validator.Valdate(user2);
        }
    }
}