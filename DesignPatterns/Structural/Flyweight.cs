//? It is used to minimize memory usage or computational expenses
//? by sharing as much as possible with similar objects.
using System;

namespace DesignPatterns.Structural
{
	public class Flyweight
	{
		static void Main()
		{
			var teaMaker = new TeaMaker();
			var shop = new TeaShop(teaMaker);

			shop.TakeOrder("Less Sugar", 1);
			shop.TakeOrder("More Milk", 2);
			shop.TakeOrder("Less Sugar", 3);
			shop.TakeOrder("More Milk", 4);
			shop.TakeOrder("Less Sugar", 5);

			shop.Serve();
		}
	}

	public class KarakTea
	{
		public string Type { get; }

		public KarakTea(string type)
		{
			Type = type;
		}
	}

	public class TeaMaker
	{
		// intrinsic state: shared data (tea type)
		private readonly Dictionary<string, KarakTea> _availableTea = new();

		public KarakTea Make(string preference)
		{
			if (!_availableTea.ContainsKey(preference))
			{
				Console.WriteLine($"Creating new tea: {preference}");
				_availableTea[preference] = new KarakTea(preference);
			}

			return _availableTea[preference];
		}
	}

	public class TeaShop
	{
		// extrinsic state: unique data (table number)
		private readonly Dictionary<int, KarakTea> _orders = new();
		private readonly TeaMaker _teaMaker;

		public TeaShop(TeaMaker teaMaker)
		{
			_teaMaker = teaMaker;
		}

		public void TakeOrder(string teaType, int table)
		{
			_orders[table] = _teaMaker.Make(teaType);
		}

		public void Serve()
		{
			foreach (var order in _orders)
			{
				Console.WriteLine($"Serving {order.Value.Type} tea to table #{order.Key}");
			}
		}
	}
}
