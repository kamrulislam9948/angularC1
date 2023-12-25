using Microsoft.EntityFrameworkCore;
using R54_M11_Class_01_Work_02.Models;

namespace R54_M11_Class_01_Work_02.HostedServices
{
    public class ApplyMigrationService
    {
        private readonly ProductDbContext db;
        public ApplyMigrationService(ProductDbContext db)
        {
            this.db = db;
        }
        public async Task ApplyMigrationAsync()
        {
            if((await db.Database.GetPendingMigrationsAsync()).Any())
            {
                await db.Database.MigrateAsync();
            }
        }
    }
}
