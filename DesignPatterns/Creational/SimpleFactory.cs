//? Simple factory simply generates an instance for client
//? without exposing any instantiation logic to the client
//* idea: A single place (method or class) that decides which object to create
//* and returns it as a common interface/base type based on input.
using System;

namespace DesignPatterns.Creational
{
	class SimpleFactory
	{
		static void Main()
		{
			INotification notifier = NotificationFactory.Create("email");
			INotification notifiersms = NotificationFactory.Create("sms");
			notifier.Send("Hello!");
			notifiersms.Send("Hi!");
		}
	}

	// 1. Product
	public interface INotification
	{
		void Send(string message);
	}

	// 2. Concrete products
	public class EmailNotification : INotification
	{
		public void Send(string message)
		{
			Console.WriteLine("Email: " + message);
		}
	}

	public class SmsNotification : INotification
	{
		public void Send(string message)
		{
			Console.WriteLine("SMS: " + message);
		}
	}

	// 3. Simple Factory
	public static class NotificationFactory
	{
		public static INotification Create(string type)
		{
			return type.ToLower() switch
			{
				"email" => new EmailNotification(),
				"sms" => new SmsNotification(),
				_ => throw new ArgumentException("Unknown type"),
			};
		}
	}
}
