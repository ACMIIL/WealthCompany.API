using WealthCompany.Data;

namespace WealthCompany.API.Configuration
{
    public static class ServicesConfiguration
    {
        public static void AddWealthCompanyServices(this IServiceCollection services)
        {
            #region Database 
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion
        }
    }
}
