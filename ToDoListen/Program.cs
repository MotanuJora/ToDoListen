
using ToDoLists;
using System.Text.Json;
using System.Text.Json.Serialization;

class Program
{
    static void Main()
    {
        List<TodoList> allLists = new List<TodoList>();

        Console.WriteLine("TodoList App V. 1.0");

        Console.WriteLine("Currently, there are no To-do lists available");
        Console.WriteLine("Please enter the name of your new list: ");

        string userInput = Console.ReadLine();

        TodoList newList = new TodoList(userInput);
        allLists.Add(newList);

        SaveLists(allLists, "lists.json");


        Console.WriteLine($"New list created! ID: {newList.TodoListId}, Name: {newList.TodoListTitle}");
        Console.WriteLine("You can now add tasks to your list");


    }

    static void SaveLists(List<TodoList> allLists, string lists)
    {
        string json = JsonSerializer.Serialize(allLists, new JsonSerializerOptions { WriteIndented = true });
        System.IO.File.WriteAllText(lists, json);
    }
}
     