using Lms.Data.Data;

namespace Lms.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task SeedDataAsync(this IApplicationBuilder application)
        {
            using (var scope = application.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var db = serviceProvider.GetRequiredService<LmsDataContext>();

                try
                {
                    await SeedData.InitAsync(db);
                }
                catch (Exception err)
                {

                    throw;
                }
            }
           
        }
    }
}
