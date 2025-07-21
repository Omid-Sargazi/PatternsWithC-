namespace LeetCode.Delegate
{
    public class PasswordValidator
    {
        private readonly List<Func<string, bool>> _rules = new();
        public PasswordValidator AddRules(Func<string, bool> rule)
        {
            _rules.Add(rule);
            return this;
        }

        public bool Validate(string password)
        {
            foreach (var rule in _rules)
            {
                if (!rule(password))
                    Console.WriteLine("❌ Password is not strong enough.");
                return false;
            }
            Console.WriteLine("✅ Password is strong.");
            return true;
        }
    }

    public class PasswordHandle
    {
        public static void Run()
        {
            var validate = new PasswordValidator()
            .AddRules(p => p.Length >= 8)
            .AddRules(p => p.Any(char.IsDigit))
            .AddRules(p => p.Any(char.IsUpper))
            .AddRules(p => p.Any(c => "!@#$%^&*()".Contains(c)));

            // validate.Validate("omid");
            validate.Validate("Pa$$w0rd");
        }
    }
}