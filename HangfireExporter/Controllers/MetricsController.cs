using Hangfire;
using Hangfire.Storage;
using Hangfire.Storage.Monitoring;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace HangfireExporter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetricsController : Controller
    {
        StringBuilder dataMetric;
        IMonitoringApi apiHangfireMonitoring;
        
        public MetricsController()
        {
            dataMetric = new StringBuilder();
            apiHangfireMonitoring = JobStorage.Current.GetMonitoringApi();
        }
        public string Get()
        {
            StatisticsDto hangfireGetStatistics;
            hangfireGetStatistics = apiHangfireMonitoring.GetStatistics();

            dataMetric.AppendLine("# HELP Servers Count");
            dataMetric.AppendLine("hangfire_servers_count " + hangfireGetStatistics.Servers.ToString());

            dataMetric.AppendLine("# HELP Queues Count");
            dataMetric.AppendLine("hangfire_queues_count " + hangfireGetStatistics.Queues.ToString());

            dataMetric.AppendLine("# HELP Enqueued Jobs Count");
            dataMetric.AppendLine("hangfire_enqueued_jobs_total_count " + hangfireGetStatistics.Enqueued.ToString());

            dataMetric.AppendLine("# HELP Deleted Jobs Count");
            dataMetric.AppendLine("hangfire_deleted_jobs_total_count " + hangfireGetStatistics.Deleted.ToString());

            dataMetric.AppendLine("# HELP Processing Jobs Count");
            dataMetric.AppendLine("hangfire_processing_jobs_total_count " + hangfireGetStatistics.Processing.ToString());

            dataMetric.AppendLine("# HELP Recurring Jobs Count");
            dataMetric.AppendLine("hangfire_recurring_jobs_count " + hangfireGetStatistics.Recurring.ToString());

            dataMetric.AppendLine("# HELP Scheduled Jobs Count");
            dataMetric.AppendLine("hangfire_scheduled_jobs_total_count " + hangfireGetStatistics.Scheduled.ToString());

            dataMetric.AppendLine("# HELP Succeeded Jobs List Count");
            dataMetric.AppendLine("hangfire_succeeded_jobs_total_count " + hangfireGetStatistics.Succeeded.ToString());

            dataMetric.AppendLine("# HELP Failed Count");
            dataMetric.AppendLine("hangfire_failed_jobs_total_count " + hangfireGetStatistics.Failed.ToString());

            return dataMetric.ToString();
        }
            
    }
}
