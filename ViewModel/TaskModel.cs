using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListAsp.NetCore.ViewModel
{
    public class TaskModel
    {
        public int?  Id { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }
    }
}
