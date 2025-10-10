
using ToDoLists;
using System.Text.Json;
using System.Text.Json.Serialization;

class Program
{
    public static void Main()
    {
        List<TodoList> allLists = LoadLists("lists.json");

        Console.WriteLine("TodoList App V. 1.0");

        ShowLists(allLists);

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Create List");
            Console.WriteLine("2. Show Lists");
            Console.WriteLine("3. Create Task");
            //Console.WriteLine("4. Show Tasks");
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
            // else if (input =-)

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
                        string description = Console.ReadLine() ?? string.Empty;
                        allLists[index - 1].AddTask(description);
                        SaveLists(allLists, "lists.json");
                        Console.WriteLine("Task added");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
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
        if (allLists.Count == 0)
        {
            Console.WriteLine("No lists available.");
            return;
        }

        for (int i = 0; i < allLists.Count; i++)
        {
            Console.WriteLine($" {i + 1}. {allLists[i].TodoListTitle}");
        }

    }
}
     