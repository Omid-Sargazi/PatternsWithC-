using System.Numerics;
using System.Reflection.Metadata;

namespace VisitorPattern.GameSystem
{
    public interface IEntity
    {
        Vector2 Position { get; set; }
        Vector2 Size { get; set; }
        string Name { get; set; }
        bool IsActive { get; set; }
        public void Accept();
    }
        public abstract class Entity : IEntity
        {
            

            public Vector2 Position { get; set;}
            public Vector2 Size { get; set;}
            public string Name { get; set;}
            public bool IsActive { get; set;}
            public Entity(Vector2 position, Vector2 size, string name, bool isActive)
            {
                Position = position;
                Size = size;
                Name = name;
                IsActive = isActive;
            }

        public abstract void Accept();
    }

    public class Player : Entity
    {
        public Player(Vector2 position, Vector2 size, string name, bool isActive) : base(position, size, name, isActive)
        {
        }
        public override void Accept()
        {
            // Implement player-specific logic here
            Console.WriteLine($"Player {Name} is at position {Position} with size {Size}");
        }
    }

    public class Enemy : Entity
    {
        public Enemy(Vector2 position, Vector2 size, string name, bool isActive) : base(position, size, name, isActive)
        {
        }

        public override void Accept()
        {
            throw new NotImplementedException();
        }
    }

    public class Item : Entity
    {
        public Item(Vector2 position, Vector2 size, string name, bool isActive) : base(position, size, name, isActive)
        {
        }

        public override void Accept()
        {
            throw new NotImplementedException();
        }
    }

    public class Obstacle : Entity
    {
        public Obstacle(Vector2 position, Vector2 size, string name, bool isActive) : base(position, size, name, isActive)
        {
        }

        public override void Accept()
        {
            throw new NotImplementedException();
        }
    }

    public class NPC : Entity
    {
        public NPC(Vector2 position, Vector2 size, string name, bool isActive) : base(position, size, name, isActive)
        {
        }

        public override void Accept()
        {
            throw new NotImplementedException();
        }
    }
    
}