using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListAsp.NetCore.Models
{
    public class Task
    {
        public int TaskID { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }
        public void MarkComplete()
        {
            IsComplete = true;
        }

        public void MarkIncomplete()
        {
            IsComplete = false;
        }
    }
}
