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
        public DateTime? DueDate { get; set; }

        public TodoItem(string todoTaskTitle)
        {
            TodoItemId = _nextId++;
            TodoTaskTitle = todoTaskTitle;
            Finished = false;
            DueDate = null;
        }

        public void MarkAsFinished()
        {
            Finished = true;
        }

        public void SetDueDate(DateTime? dueDate)
        {
            DueDate = dueDate;
        }

        public override string ToString()
        {
            string due = DueDate.HasValue ? DueDate.Value.ToString("dd-MM-yyyy") : "No due date";
            return Finished ? $"Yes {TodoTaskTitle} (Due: {due})" : $"No {TodoTaskTitle} (Due: {due})";
        }
    }
}

