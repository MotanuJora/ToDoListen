using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ToDoLists
{

    public class TodoList
    {
        private static int _nextId = 1;

        public string TodoListTitle { get; set; }
    private string TodoListDescription { get; set; } = string.Empty;
        public bool IsDone = false;
        public int TodoListId { get; }
        public List<TodoItem> Tasks { get; set; }

        public TodoList(string todoListTitle)
        {
            TodoListId = _nextId++;
            TodoListTitle = todoListTitle;
            TodoListDescription = string.Empty;
            Tasks = new List<TodoItem>();
        }

        public void AddTask(string todoTaskTitle)
        {
            if (string.IsNullOrWhiteSpace(todoTaskTitle)) return;
            Tasks.Add(new TodoItem(todoTaskTitle));
        }
     }
}


