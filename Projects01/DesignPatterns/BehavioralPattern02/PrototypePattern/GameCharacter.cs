namespace BehavioralPattern02.PrototypePattern
{
    public class GameCharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Strength { get; set; }

        public GameCharacter(){}

        public GameCharacter(GameCharacter other)
        {
            Name = other.Name;
            Health = other.Health;
            Mana = other.Mana;
            Strength = other.Strength;
        }

        public GameCharacter Clone()
        {
            return (GameCharacter)this.MemberwiseClone();
        }

        public void Display()
        {
            Console.WriteLine($"[Character] {Name} - HP: {Health}, Mana: {Mana}, STR: {Strength}");
        }
    }
}