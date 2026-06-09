//? Allows you to create different flavors of an object while avoiding constructor pollution.
//? Useful when there could be several flavors of an object. Or when there are a lot of steps involved in creation of an object.
//* idea: step-by-step object construction
using System;

namespace DesignPatterns.Creational
{
	public class Builder
	{
		static void Main()
		{
			var burger = new BurgerBuilder(14).AddCheese().AddLettuce().AddTomato().Build();

			burger.Show();
		}
	}

	public class Burger
	{
		public int Size { get; }
		public bool Cheese { get; }
		public bool Lettuce { get; }
		public bool Tomato { get; }
		public bool Pepperoni { get; }

		public Burger(BurgerBuilder builder)
		{
			Size = builder.Size;
			Cheese = builder.Cheese;
			Lettuce = builder.Lettuce;
			Tomato = builder.Tomato;
			Pepperoni = builder.Pepperoni;
		}

		public void Show()
		{
			Console.WriteLine(
				$"Burger: {Size} inch | Cheese:{Cheese} | Lettuce:{Lettuce} | Tomato:{Tomato} | Pepperoni:{Pepperoni}"
			);
		}
	}

	public class BurgerBuilder
	{
		public int Size { get; }

		public bool Cheese { get; private set; }
		public bool Lettuce { get; private set; }
		public bool Tomato { get; private set; }
		public bool Pepperoni { get; private set; }

		public BurgerBuilder(int size)
		{
			Size = size;
		}

		public BurgerBuilder AddCheese()
		{
			Cheese = true;
			return this;
		}

		public BurgerBuilder AddLettuce()
		{
			Lettuce = true;
			return this;
		}

		public BurgerBuilder AddTomato()
		{
			Tomato = true;
			return this;
		}

		public BurgerBuilder AddPepperoni()
		{
			Pepperoni = true;
			return this;
		}

		public Burger Build()
		{
			return new Burger(this);
		}
	}
}
