namespace PatternsInCSharp.StrategyPattern
{
    public interface IAttackStrategy
    {
        public string Attack();
    }

    public class MagicAttack : IAttackStrategy
    {
        public string Attack()
        {
            return "Casting a powerful spell!";
        }
    }

    public class BowAttack : IAttackStrategy
    {
        public string Attack()
        {
            return "Shooting an arrow!";
        }
    }

    public class SwordAttack : IAttackStrategy
    {
        public string Attack()
        {
            return "Swinging a sword!";
        }
    }
    public class Character
    {
        protected IAttackStrategy _attackStrategy;
        protected string Name {get; set;}
        public Character(IAttackStrategy attackStrategy, string Name)
        {
            _attackStrategy = attackStrategy;
            this.Name = Name;
        }

        public void SetAttackStrategy(IAttackStrategy attackStrategy)
        {
            _attackStrategy = attackStrategy;
        }

        public string PerformAttack()
        {
            return $"{Name} is attacking with:{_attackStrategy.Attack()}";
        }

    }
}