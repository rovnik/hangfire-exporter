using Hangfire;
using Hangfire.PostgreSql;

namespace HangfireExporter.Services
{
    public static class HangfireService
    {
        public static void AddHangfireForMetrics(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire(hfGlobalConfig =>
            {
                var dbProvider = configuration.GetSection("dbProvider").Value;
                var connectionString = configuration.GetSection("ConnectionString").Value;

                switch (dbProvider)
                {
                    case "MSSQLServer":
                        hfGlobalConfig.UseSqlServerStorage(connectionString);
                        break;
                    case "Postgres":
                        hfGlobalConfig.UsePostgreSqlStorage(connectionString);
                        break;
                    default:
                        throw new InvalidOperationException("dataMetricbase for Hangfire is not configured");
                }

            });
            services.BuildServiceProvider().GetRequiredService<IGlobalConfiguration>();
        }

    }
}
