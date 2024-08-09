# Hangfire Prometheus Exporter
:computer: :chart_with_upwards_trend: This exporter exports basic Hangfire statistics to Prometheus. Currently supports PostgreSQL and MS SQL databases.

![hangfire](https://github.com/user-attachments/assets/0167c37a-afc1-46e9-80c0-26b209bcad36)

## Exported metrics
|Metric |Meaning |
| :---:   | :---: |
| hangfire_servers_count | Servers Count   | 
| hangfire_queues_count | Queues Count   | 
| hangfire_enqueued_jobs_total_count | Enqueued Jobs Count   | 
| hangfire_deleted_jobs_total_count | Deleted Jobs Count   | 
| hangfire_processing_jobs_total_count | Processing Jobs Count   | 
| hangfire_recurring_jobs_count | Recurring Jobs Count   | 
| hangfire_scheduled_jobs_total_count | Scheduled Jobs Count   | 
| hangfire_succeeded_jobs_total_count | Succeeded Jobs Count   | 
| hangfire_failed_jobs_total_count | Failed Jobs Count   | 

### Parameters
`dbProvider` - database engine provider => MSSQLServer | Postgres |

`connectionString` - database connestion string 

# Using Docker

You can deploy this exporter using the [rovnik/hangfire-exporter](https://hub.docker.com/r/rovnik/hangfire-exporter) Docker image.

### amd64
```
docker pull rovnik/hangfire-exporter

docker run -d -p 10201:10201  -e "dbProvider=MSSQLServer" -e "connectionString=Server=(localdb)\MSSQLLocalDB; database=hangfire; integrated security=True;" --name hangfire-exporter rovnik/hangfire-exporter
```
### arm64
```
docker pull rovnik/hangfire-exporter:arm64

docker run -d -p 10201:10201  -e "dbProvider=MSSQLServer" -e "connectionString=Server=(localdb)\MSSQLLocalDB; database=hangfire; integrated security=True;" --name hangfire-exporter rovnik/hangfire-exporter
```

## :heavy_check_mark: TODO : 
- Add more database providers
- Introduce additional metrics 
