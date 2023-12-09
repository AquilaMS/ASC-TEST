using ASC_TEST.Data;
using Microsoft.EntityFrameworkCore;

namespace ASC_TEST.Services
{
    public class DbManager
    {
        public static void MigrationInit(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<AppDbContext>().Database.Migrate();
            }
        }
    }
}
