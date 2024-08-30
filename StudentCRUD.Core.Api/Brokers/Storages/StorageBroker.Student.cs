using Microsoft.EntityFrameworkCore;
using StudentCRUD.Core.Api.Models.Students;

namespace StudentCRUD.Core.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Student> Students { get; set; }

        public async ValueTask<Student> InsertStudentAsync(Student student) =>
            await InsertAsync(student);
    }
}
