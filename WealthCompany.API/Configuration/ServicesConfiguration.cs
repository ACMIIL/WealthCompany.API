using WealthCompany.Business;
using WealthCompany.Data;
using WealthCompany.Data.Repository;
using WealthCompany.Service;
using Microsoft.Extensions.DependencyInjection;
using WealthCompany.Business.Helper;

namespace WealthCompany.API.Configuration
{
    public static class ServicesConfiguration
    {
        public static void AddWealthCompanyServices(this IServiceCollection services)
        {
            // Database Services
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // AgentLogin Services
            services.AddScoped<IAgentLoginManager, AgentLoginManager>();
            services.AddScoped<IAgentLoginservice, AgentLoginservice>();
            services.AddScoped<IAgentLoginRepository, AgentLoginRepository>();
            services.AddScoped<ISendMessageHelper, SendMessageHelper>();
            services.AddScoped<ISendMessageHelper, SendMessageHelper>();


            // Add other services as needed

            // You can also add other service registrations here

            // Example:
            // services.AddScoped<IOtherService, OtherService>();
        }
    }
}
