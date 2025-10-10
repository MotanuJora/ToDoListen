
using ToDoLists;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

class Program
{
    public static void Main()
    {
        List<TodoList> allLists = LoadLists("lists.json");

        Console.WriteLine("TodoList App V. 1.0");

        if (allLists.Count == 0)
        {
            Console.WriteLine("No lists available. Go ahead and create a new one!\n");
        }

            while (true)
            {
                Console.WriteLine("1. Create List");
                Console.WriteLine("2. Show Lists");
                Console.WriteLine("3. Create Task");
                Console.WriteLine("4. Show Tasks");
                Console.WriteLine("0. Exit");
                Console.Write("Choose: ");

                string userInput = Console.ReadLine() ?? string.Empty;

                if (userInput == "0")
                {
                    Console.WriteLine("Exit");
                    SaveLists(allLists, "lists.json");
                    break;
                }

            if (userInput == "1")
            {
                Console.Write("Please enter the name of your new list: ");
                userInput = Console.ReadLine() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    TodoList newList = new TodoList(userInput);
                    allLists.Add(newList);
                    SaveLists(allLists, "lists.json");
                    Console.WriteLine($"New list created! ID: {newList.TodoListId}, Name: {newList.TodoListTitle}");
                }
                else
                {
                    Console.WriteLine("Invalid list name");
                }
            }
            else if (userInput == "2")
            {
                Console.WriteLine("Here are your lists:");
                ShowLists(allLists);

                Console.WriteLine("\nWould you like to change their names? (Y/N): ");
                userInput = Console.ReadLine() ?? string.Empty;

                if (userInput == "Y")
                {

                    foreach (var list in allLists)
                    {
                        Console.WriteLine($"ID: {list.TodoListId} | Title: {list.TodoListTitle}");
                    }

                    Console.WriteLine("\nWhich list would you like to change the name of? (ID): ");
                    
                                                        
                    userInput = Console.ReadLine() ?? string.Empty;

                    if (int.TryParse(userInput, out int idForRename))

                    {
                        TodoList listToRename = allLists.Find(l => l.TodoListId == idForRename);

                        if (listToRename != null) { 
                        
                            Console.Write("What would you like it changed to?: ");
                            string newListName = Console.ReadLine() ?? "N/A";

                            listToRename.TodoListTitle = newListName;
                            SaveLists(allLists, "lists.json");

                            Console.WriteLine("List renamed successfully!");

                        }
                        else
                        {
                           Console.WriteLine("No list found with that ID.");
                        }
                    } else { Console.WriteLine("Invalid ID format."); }

                    

                                                         
    

                }
           
            }


            else if (userInput == "3")
            {
                if (allLists.Count == 0)
                {
                    Console.WriteLine("No Lists available");
                }
                else
                {
                    Console.WriteLine("To which list do you want to add a task?");
                    for (int i = 0; i < allLists.Count; i++)
                        Console.WriteLine($"{i + 1}. {allLists[i].TodoListTitle}");

                    Console.Write("Enter number: ");
                    string sel = Console.ReadLine() ?? string.Empty;
                    if (int.TryParse(sel, out int index) && index > 0 && index <= allLists.Count)
                    {
                        Console.Write("Enter a task: ");
                        string todoTaskTitle = Console.ReadLine() ?? string.Empty;
                        allLists[index - 1].AddTask(todoTaskTitle);
                        SaveLists(allLists, "lists.json");
                        Console.WriteLine("Task added");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
            }

            else if (userInput == "4")
            {
                Console.WriteLine("Here are your tasks:");
                if (allLists.Count == 0)
                {
                    Console.WriteLine("No lists available.");
                }
                else
                {
                    for (int i = 0; i < allLists.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {allLists[i].TodoListTitle}");
                        foreach (var task in allLists[i].Tasks)
                        {
                            if (task.Finished == true) {
                                Console.WriteLine($" {task.TodoItemId} - {task.TodoTaskTitle} (finished)");
                                
                            
                            } else { Console.WriteLine($" {task.TodoItemId} - {task.TodoTaskTitle}"); }
                            
                            
                            


                        }

                        Console.WriteLine("Would you like to mark any tasks as finished? (Y/N):");
                        userInput = Console.ReadLine() ?? string.Empty;
                        if (userInput == "Y")
                        {
                            Console.WriteLine("Which task?");
                            userInput = Console.ReadLine() ?? string.Empty ;

                            if (int.TryParse(userInput, out int id))
                            {
                                TodoItem TasktoMarkFinished = allLists[i].Tasks.Find (l => l.TodoItemId == id);

                                if (TasktoMarkFinished != null) { 
                                TasktoMarkFinished.Finished = true;
                                    Console.WriteLine("Task was successfully marked as finished.");

                                } else { Console.WriteLine("No task found with that ID."); }
                            }

                        }
                        


                    }


                }
            }
                
            






            else
            {
                Console.WriteLine("Invalid input");
            }

            

            

                
            }
    }

    static List<TodoList> LoadLists(string path)
    {
        try
        {
            if (!System.IO.File.Exists(path)) return new List<TodoList>();
            string json = System.IO.File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<TodoList>>(json) ?? new List<TodoList>();
        }
        catch
        {
            return new List<TodoList>();
        }
    }

    static void SaveLists(List<TodoList> allLists, string lists)
    {
        string json = JsonSerializer.Serialize(allLists, new JsonSerializerOptions { WriteIndented = true });
        System.IO.File.WriteAllText(lists, json);
    }

    public static void ShowLists(List<TodoList> allLists)
    {
        
        for (int i = 0; i < allLists.Count; i++)
        {
            Console.WriteLine($" {i + 1}. {allLists[i].TodoListTitle}");
        }

    }
}
     