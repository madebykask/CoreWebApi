using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoWeb.Models;

namespace ToDoWeb.Data
{
    public class ToDoWebContext : DbContext
    {
        public ToDoWebContext (DbContextOptions<ToDoWebContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoWeb.Models.TodoItem> TodoItem { get; set; }
    }
}
