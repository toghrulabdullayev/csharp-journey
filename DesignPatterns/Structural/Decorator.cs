//? Decorator pattern lets you dynamically change the behavior of an object at run time
//? by wrapping them in an object of a decorator class.
//* idea: I have an object. I want to add extra behavior without modifying its class
//* and without creating 50 subclasses."
using System;

namespace DesignPatterns.Structural
{
	public class Decorator
	{
		static void Main()
		{
			ICoffee coffee = new SimpleCoffee();

			Console.WriteLine(coffee.GetCost());
			Console.WriteLine(coffee.GetDescription());

			coffee = new MilkCoffee(coffee);

			Console.WriteLine(coffee.GetCost());
			Console.WriteLine(coffee.GetDescription());

			coffee = new WhipCoffee(coffee);

			Console.WriteLine(coffee.GetCost());
			Console.WriteLine(coffee.GetDescription());

			coffee = new VanillaCoffee(coffee);

			Console.WriteLine(coffee.GetCost());
			Console.WriteLine(coffee.GetDescription());

			coffee = new VanillaCoffee(new WhipCoffee(new MilkCoffee(new SimpleCoffee())));

			Console.WriteLine(coffee.GetCost());
			Console.WriteLine(coffee.GetDescription());
		}
	}

	// component interface
	public interface ICoffee
	{
		double GetCost();
		string GetDescription();
	}

	// concrete component
	public class SimpleCoffee : ICoffee
	{
		public double GetCost() => 10;

		public string GetDescription() => "Simple Coffee";
	}

	// base decorator
	public abstract class CoffeeDecorator : ICoffee
	{
		protected readonly ICoffee Coffee;

		protected CoffeeDecorator(ICoffee coffee)
		{
			Coffee = coffee;
		}

		public virtual double GetCost()
		{
			return Coffee.GetCost();
		}

		public virtual string GetDescription()
		{
			return Coffee.GetDescription();
		}
	}

	// concrete decorators
	public class MilkCoffee : CoffeeDecorator
	{
		public MilkCoffee(ICoffee coffee)
			: base(coffee) { }

		public override double GetCost()
		{
			return Coffee.GetCost() + 2;
		}

		public override string GetDescription()
		{
			return Coffee.GetDescription() + ", Milk";
		}
	}

	public class WhipCoffee : CoffeeDecorator
	{
		public WhipCoffee(ICoffee coffee)
			: base(coffee) { }

		public override double GetCost()
		{
			return Coffee.GetCost() + 5;
		}

		public override string GetDescription()
		{
			return Coffee.GetDescription() + ", Whip";
		}
	}

	public class VanillaCoffee : CoffeeDecorator
	{
		public VanillaCoffee(ICoffee coffee)
			: base(coffee) { }

		public override double GetCost()
		{
			return Coffee.GetCost() + 3;
		}

		public override string GetDescription()
		{
			return Coffee.GetDescription() + ", Vanilla";
		}
	}
}
