using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using to_do_it_by_command.cmd;
using to_do_it_by_command.cmd.Interfaces;
using to_do_it_by_command.fs_tasks;

namespace to_do_it_by_command
{
	class Program
	{
		public static void Main(string[] args)
		{
			// setup Dependency Injection
			var host = Host.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration((context, config) =>
				{
					// add appsettings to the configuration
					config.SetBasePath(Directory.GetCurrentDirectory())
						.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
				})
				.ConfigureServices((context, services) =>
				{
					// register the configuration section in DI
					services.Configure<FileSettings>(context.Configuration.GetSection("FileSettings"));

					// register services or classes that need access to the configuration
					services.AddTransient<FsJson>();
					services.AddTransient<Tasks>();

					// register commands and the command factory
					services.AddTransient<ICommand, AddCommand>();
					services.AddTransient<ICommand, UpdateCommand>();
					services.AddTransient<ICommand, MarkToDoCommand>();
					services.AddTransient<ICommand, MarkInProgressCommand>();
					services.AddTransient<ICommand, MarkDoneCommand>();
					services.AddTransient<ICommand, NotFoundCommand>();
					services.AddTransient<ICommand, HelpCommand>();
					services.AddSingleton<CommandFactory>();

					services.AddTransient<Processor>();
				})
				.Build();


			// start application
			var processor = host.Services.GetRequiredService<Processor>();
			processor.StartApplication();
		}
	}
}