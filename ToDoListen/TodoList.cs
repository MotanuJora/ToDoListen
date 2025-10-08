using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ToDoLists
{

    class TodoList
    {

        public string TodoListTitle {  get; set; }
        private string TodoListDescription {  get; set; }
        public bool IsDone = false;
        public int TodoListId { get;}



        public List<string> Tasks { get; set; }

        private static int _nextId = 1;
        public TodoList(string todoListTitle) {

            TodoListId = _nextId++;
            TodoListTitle = todoListTitle;
            Tasks = new List<string>();
            Console.WriteLine($"{TodoListTitle} list created!");
        
        }
        
        
        
        



     
    }
}
