namespace Patterns.RegisterSchool
{
    public class UserValidator 
    {
        private readonly List<IUserValidationStrategy> _strategies;
        public UserValidator(List<IUserValidationStrategy> strategies)
        {
            _strategies = strategies;
        }
        public bool Validate(User user, out List<string> errors)
        {
            errors = new List<string>();
            foreach(var strategy in _strategies)
            {
                if(!strategy.IsValid(user))
                {
                    errors.Add(strategy.ErrorMessage);
                }
            }
            return errors.Count == 0;
        }
    }
}