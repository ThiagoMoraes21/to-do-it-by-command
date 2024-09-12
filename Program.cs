using System;

namespace to_do_it_by_command
{
	class Program // The class that contains the Main method
	{
		public static void Main()
		{
			var processor = new Processor();
			Console.WriteLine("To Do It By Command");
			Console.WriteLine("Enter 'exit' to close the application.");

			while (true)
			{
				Console.Write("\n> ");
				string? input = Console.ReadLine();

				if (string.IsNullOrEmpty(input) || input.Length == 0) continue;

				string[] inputParts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
				string task = inputParts.First().ToLower();
				string[] parameters = inputParts[1..];

				if(task == "exit")
				{
					Console.WriteLine("See ya!!");
					break;
				}

				processor.Process(task, parameters);
			}
		}
	}
}