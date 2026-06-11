//? Using the proxy pattern, a class represents the functionality of another class.
//* idea: A Proxy is an object that controls access to another object and optionally
//* adds logic before/after it.
using System;

namespace DesignPatterns.Structural
{
	public class Proxy
	{
		static void Main()
		{
			ISecuredDoor securedDoor = new SecuredDoor(new LabDoor());

			securedDoor.Open(); // not authenticated

			securedDoor.Authenticate("wrong");
			securedDoor.Open(); // still blocked

			securedDoor.Authenticate("$ecr@t");
			securedDoor.Open(); // Opening lab door

			securedDoor.Close(); // Closing lab door
			securedDoor.Open(); // Opening lab door
		}
	}

	// subject (interface)
	public interface IDoor
	{
		void Open();
		void Close();
	}

	public interface ISecuredDoor : IDoor
	{
		void Authenticate(string password);
	}

	// real object (actual logic)
	public class LabDoor : IDoor
	{
		public void Open()
		{
			Console.WriteLine("Opening lab door");
		}

		public void Close()
		{
			Console.WriteLine("Closing lab door");
		}
	}

	// proxy (controls access to real object)
	public class SecuredDoor : ISecuredDoor
	{
		private readonly IDoor _door;
		private bool _isAuthenticated;

		public SecuredDoor(IDoor door)
		{
			_door = door;
		}

		public void Authenticate(string password)
		{
			_isAuthenticated = password == "$ecr@t";
		}

		public void Open()
		{
			if (_isAuthenticated)
			{
				_door.Open();
			}
			else
			{
				Console.WriteLine("Big no! It ain't possible.");
			}
		}

		public void Close()
		{
			_isAuthenticated = false; // lock the door again
			_door.Close();
		}
	}
}
