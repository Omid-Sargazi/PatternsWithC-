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
        public void Accept(IEntityVisitor entity);
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

        public abstract void Accept(IEntityVisitor entity);
    }

    public class Player : Entity
    {
         public int Health { get; set; }
        public int ManaPoints { get; set; }
        public List<string> Inventory { get; set; }
        public Player(Vector2 position, Vector2 size, string name, bool isActive) : base(position, size, name, isActive)
        {
            Health = 100;
            ManaPoints = 50;
            Inventory = new List<string>();
        }
        public override void Accept(IEntityVisitor entity)
        {
            entity.Visit(this);
            // Implement player-specific logic here
        }
    }

    public class Enemy : Entity
    {
        public int Health { get; set; }
        public int Damage { get; set; }
        public string EnemyType { get; set; }
        public Enemy(Vector2 position, Vector2 size, string name, bool isActive) : base(position, size, name, isActive)
        {
        }

        public override void Accept(IEntityVisitor entity)
        {
            entity.Visit(this);
        }
    }

    public class Item : Entity
    {
         public string ItemType { get; set; }
        public bool IsCollectible { get; set; }
        public Item(Vector2 position, Vector2 size,string itemType, bool isCollectible) : base(position, size, new Vector2(0.5f, 0.5f))
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

    public interface IEntityVisitor
    {
        void Visit(Player player);
        void Visit(Enemy enemy);
        void Visit(Item item);
        void Visit(Obstacle obstacle);
    }

    public class RenderingVisitor : IEntityVisitor
    {
        public void Visit(Player player)
        {
            throw new NotImplementedException();
        }

        public void Visit(Enemy enemy)
        {
            throw new NotImplementedException();
        }

        public void Visit(Item item)
        {
            throw new NotImplementedException();
        }

        public void Visit(Obstacle obstacle)
        {
            throw new NotImplementedException();
        }
    }

    public class PhysicsVisitor : IEntityVisitor
    {
        public void Visit(Player player)
        {
            throw new NotImplementedException();
        }

        public void Visit(Enemy enemy)
        {
            throw new NotImplementedException();
        }

        public void Visit(Item item)
        {
            throw new NotImplementedException();
        }

        public void Visit(Obstacle obstacle)
        {
            throw new NotImplementedException();
        }
    }

    public class CollisionVisitor : IEntityVisitor
    {
        public void Visit(Player player)
        {
            throw new NotImplementedException();
        }

        public void Visit(Enemy enemy)
        {
            throw new NotImplementedException();
        }

        public void Visit(Item item)
        {
            throw new NotImplementedException();
        }

        public void Visit(Obstacle obstacle)
        {
            throw new NotImplementedException();
        }
    }

    public class SaveStateVisitor : IEntityVisitor
    {
        public void Visit(Player player)
        {
            throw new NotImplementedException();
        }

        public void Visit(Enemy enemy)
        {
            throw new NotImplementedException();
        }

        public void Visit(Item item)
        {
            throw new NotImplementedException();
        }

        public void Visit(Obstacle obstacle)
        {
            throw new NotImplementedException();
        }
    }

}