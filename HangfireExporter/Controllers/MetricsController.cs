using Hangfire;
using Hangfire.Storage;
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
            dataMetric.AppendLine("# HELP Servers Count ");
            dataMetric.AppendLine("hangfire_servers_count " + apiHangfireMonitoring.GetStatistics().Servers.ToString());

            dataMetric.AppendLine("# HELP Queues Count");
            dataMetric.AppendLine("hangfire_queues_count " + apiHangfireMonitoring.GetStatistics().Queues.ToString());

            dataMetric.AppendLine("# HELP Enqueued Jobs Count");
            dataMetric.AppendLine("hangfire_enqueued_jobs_total_count " + apiHangfireMonitoring.GetStatistics().Enqueued.ToString());

            dataMetric.AppendLine("# HELP Deleted Jobs Count");
            dataMetric.AppendLine("hangfire_deleted_jobs_total_count " + apiHangfireMonitoring.GetStatistics().Deleted.ToString());

            dataMetric.AppendLine("# HELP Processing Jobs Count");
            dataMetric.AppendLine("hangfire_processing_jobs_total_count " + apiHangfireMonitoring.GetStatistics().Processing.ToString());

            dataMetric.AppendLine("# HELP Recurring Jobs Count");
            dataMetric.AppendLine("hangfire_recurring_jobs_count " + apiHangfireMonitoring.GetStatistics().Recurring.ToString());

            dataMetric.AppendLine("# HELP Scheduled Jobs Count");
            dataMetric.AppendLine("hangfire_scheduled_jobs_total_count " + apiHangfireMonitoring.GetStatistics().Scheduled.ToString());

            dataMetric.AppendLine("# HELP Succeeded Jobs List Count");
            dataMetric.AppendLine("hangfire_succeeded_jobs_total_count " + apiHangfireMonitoring.GetStatistics().Succeeded.ToString());

            dataMetric.AppendLine("# HELP Failed Count");
            dataMetric.AppendLine("hangfire_failed_jobs_total_count " + apiHangfireMonitoring.GetStatistics().Failed.ToString());

            return dataMetric.ToString();
        }
            
    }
}
