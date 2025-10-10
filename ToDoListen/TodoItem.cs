using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoLists
{
    public class TodoItem
    {
        private static int _nextId = 1;
        public int TodoItemId { get; set; }
        public string TodoTaskTitle { get; set; }
        public bool Finished { get; set; }

        public TodoItem(string todoTaskTitle)
        {
            TodoItemId = _nextId++;
            TodoTaskTitle = todoTaskTitle;
            Finished = false;
        }

        public void MarkAsFinished()
        {
            Finished = true;
        }

        public override string ToString()
        {
            return Finished ? $"Yes {TodoTaskTitle}" : $"No {TodoTaskTitle}";
        }
    }
}

