using Microsoft.EntityFrameworkCore;
using MyNotes.Core.Models;

namespace MyNotes.Infrastructure
{
    public class MyNotesContext : DbContext
    {
        public MyNotesContext(DbContextOptions<MyNotesContext> options) : base(options)
        {
        }
        public DbSet<Notes> Note { get; set; }
    }
}
