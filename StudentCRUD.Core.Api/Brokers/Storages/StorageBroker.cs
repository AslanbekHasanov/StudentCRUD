using Microsoft.EntityFrameworkCore;
using StudentCRUD.Core.Api.Models.Students;
using STX.EFxceptions.Core;
using STX.EFxceptions.SqlServer;

namespace StudentCRUD.Core.Api.Brokers.Storages
{
    public partial class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }

        private async ValueTask<T> InsertAsync<T>(T @object)
        {
            var broker = new StorageBroker(this.configuration);

            broker.Entry(@object).State = EntityState.Added;
            await broker.SaveChangesAsync();

            return @object;
        }

        public IQueryable<T> SelectAll<T>() where T : class
        {
            var broker = new StorageBroker(this.configuration);

            return broker.Set<T>();
        }

        private async ValueTask<T> SelectAsync<T>(params object[] objectIds) where T : class =>
         await FindAsync<T>(objectIds);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
            this.configuration.GetConnectionString("ApplicationConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
