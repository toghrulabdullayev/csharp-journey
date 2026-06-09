//? A factory of factories; a factory that groups the individual but
//? related/dependent factories together without specifying their concrete classes.
using System;

namespace DesignPatterns.Creational
{
	public class AbstractFactory
	{
		static void Main()
		{
			IUIFactory factory;

			string os = "windows";

			if (os == "windows")
			{
				factory = new WindowsUIFactory();
			}
			else
			{
				factory = new MacUIFactory();
			}

			var app = new Application(factory);
			app.RenderUI();
		}
	}

	// =======================
	// Abstract Products
	// =======================

	public interface IButton
	{
		void Render();
	}

	public interface ICheckbox
	{
		void Render();
	}

	// =======================
	// Windows Products
	// =======================

	public class WindowsButton : IButton
	{
		public void Render()
		{
			Console.WriteLine("Rendering Windows Button");
		}
	}

	public class WindowsCheckbox : ICheckbox
	{
		public void Render()
		{
			Console.WriteLine("Rendering Windows Checkbox");
		}
	}

	// =======================
	// Mac Products
	// =======================

	public class MacButton : IButton
	{
		public void Render()
		{
			Console.WriteLine("Rendering Mac Button");
		}
	}

	public class MacCheckbox : ICheckbox
	{
		public void Render()
		{
			Console.WriteLine("Rendering Mac Checkbox");
		}
	}

	// =======================
	// Abstract Factory
	// =======================

	public interface IUIFactory
	{
		IButton CreateButton();
		ICheckbox CreateCheckbox();
	}

	// =======================
	// Concrete Factories
	// =======================

	public class WindowsUIFactory : IUIFactory
	{
		public IButton CreateButton()
		{
			return new WindowsButton();
		}

		public ICheckbox CreateCheckbox()
		{
			return new WindowsCheckbox();
		}
	}

	public class MacUIFactory : IUIFactory
	{
		public IButton CreateButton()
		{
			return new MacButton();
		}

		public ICheckbox CreateCheckbox()
		{
			return new MacCheckbox();
		}
	}

	// =======================
	// Client
	// =======================

	public class Application
	{
		private readonly IButton _button;
		private readonly ICheckbox _checkbox;

		public Application(IUIFactory factory)
		{
			_button = factory.CreateButton();
			_checkbox = factory.CreateCheckbox();
		}

		public void RenderUI()
		{
			_button.Render();
			_checkbox.Render();
		}
	}
}
