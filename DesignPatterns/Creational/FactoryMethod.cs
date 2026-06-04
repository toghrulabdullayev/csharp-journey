//? Provides a way to delegate the instantiation logic to child classes.
//* idea: Remove knowledge of which concrete class is being used from the calling code
using System;

namespace DesignPatterns.Creational
{
	// Client
	class FactoryMethod
	{
		static void Main()
		{
			HiringManager devManager = new DevelopmentManager();
			devManager.TakeInterview();

			HiringManager marketingManager = new MarketingManager();
			marketingManager.TakeInterview();
		}
	}

	// Product
	public interface IInterviewer
	{
		void AskQuestions();
	}

	// Concrete Products
	public class Developer : IInterviewer
	{
		public void AskQuestions()
		{
			Console.WriteLine("Asking about design patterns!");
		}
	}

	public class CommunityExecutive : IInterviewer
	{
		public void AskQuestions()
		{
			Console.WriteLine("Asking about community building!");
		}
	}

	// Creator
	public abstract class HiringManager
	{
		// Factory Method
		protected abstract IInterviewer MakeInterviewer();

		public void TakeInterview()
		{
			var interviewer = MakeInterviewer();
			interviewer.AskQuestions();
		}
	}

	// Concrete Creators
	public class DevelopmentManager : HiringManager
	{
		protected override IInterviewer MakeInterviewer()
		{
			return new Developer();
		}
	}

	public class MarketingManager : HiringManager
	{
		protected override IInterviewer MakeInterviewer()
		{
			return new CommunityExecutive();
		}
	}
}
