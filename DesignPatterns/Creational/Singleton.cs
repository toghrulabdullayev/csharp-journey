//? Ensures that only one object of a particular class is ever created.
//* a class that allows only ONE instance for the whole application.
using System;

namespace DesignPatterns.Creational
{
	public class Singleton
	{
		static void Main()
		{
			var logger1 = Logger.Instance;
			var logger2 = Logger.Instance;

			logger1.Log("Hello");

			Console.WriteLine(logger1 == logger2); // True
		}
	}

	// thread-safe, lazy initialization, and ensures that only one instance of Logger is created throughout the application.
	public sealed class Logger
	{
		private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());

		public static Logger Instance => _instance.Value;

		private Logger()
		{
			Console.WriteLine("Logger created");
		}

		public void Log(string message)
		{
			Console.WriteLine($"LOG: {message}");
		}
	}

	// simple version (basic, not thread-safe)
	public sealed class Logger2
	{
		private static Logger2? _instance;

		private Logger2() { }

		public static Logger2 Instance
		{
			get
			{
				if (_instance == null)
					_instance = new Logger2();

				return _instance;
			}
		}
	}
}
