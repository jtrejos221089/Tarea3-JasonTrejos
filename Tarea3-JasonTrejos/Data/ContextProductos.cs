using Microsoft.EntityFrameworkCore;
using Tarea3_JasonTrejos.Models;

namespace Tarea3_JasonTrejos.Data
{
    public class ContextProductos : DbContext
    {
        public ContextProductos(DbContextOptions<ContextProductos> options) : base(options)
        {
            
        }

        public DbSet<Productos> productos { get; set; }
    }
}
