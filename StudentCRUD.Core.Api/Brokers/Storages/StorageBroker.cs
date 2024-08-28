using Microsoft.EntityFrameworkCore;
using StudentCRUD.Core.Api.Models.Students;
using STX.EFxceptions.Core;
using STX.EFxceptions.SqlServer;

namespace StudentCRUD.Core.Api.Brokers.Storages
{
    public class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
            this.configuration.GetConnectionString("ApplicationConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }


    }
}
