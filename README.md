# To Do It By Command

A To-Do CLI app made with C#/.Net using the [Command Design Pattern](https://refactoring.guru/design-patterns/command).
Sample solution for the [task-tracker](https://roadmap.sh/projects/task-tracker) challenge from [roadmap.sh](https://roadmap.sh/).

## How to run

Clone the repository and run the following command:

```bash
git clone https://github.com/ThiagoMoraes21/to-do-it-by-command.git
cd to-do-it-by-command
```

Run the following command to build and run the project:

```bash
dotnet build && dotnet run
help # To see the list of available commands
exit # To exit the application

# To add a task
add "Buy groceries"

# To update a task
update 1 "Buy groceries and cook dinner"

# To delete a task
delete 1

# To mark a task as in progress/done/todo
mark-in-progress 1
mark-done 1
mark-todo 1

# To list all tasks
list
list done
list to-do
list in-progress
```
