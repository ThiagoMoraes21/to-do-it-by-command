using to_do_it_by_command.cmd;

namespace to_do_it_by_command
{
    public class Processor
    {
        private readonly CommandFactory _commandFactory;

        public Processor(CommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public void StartApplication()
        {
            Console.WriteLine("To Do It By Command");
            Console.WriteLine("Enter 'exit' to close the application.");
            Console.WriteLine("Enter 'help' to see the available commands and options.");

            while (true)
            {
                Console.Write("\n> ");
                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || input.Length == 0) continue;

                string[] inputParts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string task = inputParts.First().ToLower();
                string[] parameters = inputParts[1..];

                if (task == "exit")
                {
                    Console.WriteLine("See ya!!");
                    break;
                }

                Process(task, parameters);
            }
        }

        private void Process(string task, string[] args)
        {
            var command = _commandFactory.CreateCommand(task, args);
            command.Execute();
        }
    }
}