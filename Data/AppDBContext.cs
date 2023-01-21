using Microsoft.EntityFrameworkCore;
using Todo2811.Models;

namespace Todo2811.Data
{
    public class AppDBContext : DbContext
    {
        DbSet<TodoModel> Todos;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
=> options.UseSqlite("DataSource=app.db;Cache=Shared");

    }
}