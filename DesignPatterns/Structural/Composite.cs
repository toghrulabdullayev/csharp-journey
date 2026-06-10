//? Composite pattern lets clients treat the individual objects in a uniform manner.
//* idea: leaf objects (Developer, Designer) and composite objects (Manager, CEO, Department, Organization) implement the same interface.
using System;

namespace DesignPatterns.Structural
{
	public class Composite
	{
		static void Main()
		{
			var john = new Developer("John", 12000);
			var jane = new Designer("Jane", 15000);
			var bob = new Developer("Bob", 10000);

			var manager = new Manager("Alice", 25000);
			var manager2 = new Manager("Charlie", 30000);

			manager.Add(john);
			manager.Add(jane);
			manager.Add(bob);
			manager2.Add(new Developer("Dave", 11000));
			manager2.Add(new Designer("Ellen", 13000));

			var ceo = new CEO("Eve", 50000);
			ceo.Add(manager);
			ceo.Add(manager2);

			ceo.Display();

			Console.WriteLine();
			Console.WriteLine($"Total Salary Cost: ${ceo.GetSalary()}");
		}
	}

	public interface IEmployee
	{
		string Name { get; }
		decimal GetSalary();
		void Display(int depth = 0);
	}

	public class Developer : IEmployee
	{
		public string Name { get; }
		private decimal Salary { get; }

		public Developer(string name, decimal salary)
		{
			Name = name;
			Salary = salary;
		}

		public decimal GetSalary()
		{
			return Salary;
		}

		public void Display(int depth = 0)
		{
			// repeat empty space depth * 2 times for indentation
			Console.WriteLine($"{new string(' ', depth * 2)}Developer: {Name} (${Salary})");
		}
	}

	public class Designer : IEmployee
	{
		public string Name { get; }
		private decimal Salary { get; }

		public Designer(string name, decimal salary)
		{
			Name = name;
			Salary = salary;
		}

		public decimal GetSalary()
		{
			return Salary;
		}

		public void Display(int depth = 0)
		{
			Console.WriteLine($"{new string(' ', depth * 2)}Designer: {Name} (${Salary})");
		}
	}

	public class Manager : IEmployee
	{
		public string Name { get; }
		private decimal Salary { get; }

		// or [] instead of new() for simplicity (both infer the type from the declaration)
		private readonly List<IEmployee> _subordinates = new();

		public Manager(string name, decimal salary)
		{
			Name = name;
			Salary = salary;
		}

		public void Add(IEmployee employee)
		{
			_subordinates.Add(employee);
		}

		public void Remove(IEmployee employee)
		{
			_subordinates.Remove(employee);
		}

		public decimal GetSalary()
		{
			decimal total = Salary;

			foreach (var employee in _subordinates)
			{
				total += employee.GetSalary();
			}

			return total;
		}

		public void Display(int depth = 0)
		{
			Console.WriteLine($"{new string(' ', depth * 2)}Manager: {Name} (${Salary})");

			foreach (var employee in _subordinates)
			{
				employee.Display(depth + 1);
			}
		}
	}

	public class CEO : IEmployee
	{
		public string Name { get; }
		private decimal Salary { get; }

		private readonly List<IEmployee> _subordinates = new();

		public CEO(string name, decimal salary)
		{
			Name = name;
			Salary = salary;
		}

		public void Add(IEmployee employee)
		{
			_subordinates.Add(employee);
		}

		public void Remove(IEmployee employee)
		{
			_subordinates.Remove(employee);
		}

		public decimal GetSalary()
		{
			decimal total = Salary;

			foreach (var employee in _subordinates)
			{
				total += employee.GetSalary();
			}

			return total;
		}

		public void Display(int depth = 0)
		{
			Console.WriteLine($"{new string(' ', depth * 2)}CEO: {Name} (${Salary})");

			foreach (var employee in _subordinates)
			{
				employee.Display(depth + 1);
			}
		}
	}
}
