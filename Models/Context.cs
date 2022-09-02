using Microsoft.EntityFrameworkCore;

namespace TesteSinqia.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options): base(options)
        {

        }

        public DbSet<PontoTuristicoModel> PontoTuristicoModels { get; set; }
    }
}
