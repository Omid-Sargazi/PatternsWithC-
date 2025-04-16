namespace Patterns.RegisterSchool
{
    public class PasswordValidator 
    {
        private List<IPasswordValidationStrategy> _strategies;
        public PasswordValidator()
        {
            _strategies =  new List<IPasswordValidationStrategy>
            {
                new MinimumLengthStrategy(),
                new ContainsNumberStrategy(),
                new NotSameAsUsernameStrategy()
            };
        }

        public bool Validate(string password, string userName, out List<string> errors)
        {
            errors = new List<string>();
            foreach(var strategy in _strategies)
            {
                if(!strategy.IsValid(password, userName))
                {
                    errors.Add(strategy.ErorMessage);
                }
            }
            return errors.Count == 0;
        }
        
    }
}