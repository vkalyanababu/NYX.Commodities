using Microsoft.EntityFrameworkCore;
using NYX.Commodities.Services.ProductAPI.Data;

namespace NYX.Commodities.Services.ProductAPI
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<ProductDBContext>();
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            return webApp;
        }
    }
}
