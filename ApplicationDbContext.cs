using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListAsp.NetCore.Models;
using Task = ToDoListAsp.NetCore.Models.Task;

namespace ToDoListAsp.NetCore
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
        
    }
}
