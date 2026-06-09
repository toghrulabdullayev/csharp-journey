//? Create object based on an existing object through cloning.
//! Unlike factory, prototype copies
using System;

namespace DesignPatterns.Creational
{
	public class Prototype
	{
		static void Main()
		{
			// Create prototype
			var warriorTemplate = new Warrior("Base Warrior", 100, 20);

			// Clone prototype
			var warrior1 = warriorTemplate.Clone();
			warrior1.Name = "Thor";

			var warrior2 = warriorTemplate.Clone();
			warrior2.Name = "Loki";
			warrior2.Health = 80;

			warriorTemplate.Display();
			warrior1.Display();
			warrior2.Display();
		}
	}

	// Prototype Interface
	public interface IPrototype<T>
	{
		T Clone();
	}

	// Concrete Prototype
	public class Warrior : IPrototype<Warrior>
	{
		public string Name { get; set; }
		public int Health { get; set; }
		public int AttackPower { get; set; }

		public Warrior(string name, int health, int attackPower)
		{
			Name = name;
			Health = health;
			AttackPower = attackPower;
		}

		public Warrior Clone()
		{
			return (Warrior)MemberwiseClone();
		}

		public void Display()
		{
			Console.WriteLine($"Name: {Name}, Health: {Health}, Attack: {AttackPower}");
		}
	}
}
