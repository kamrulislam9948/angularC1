namespace R54_M11_Class_01_Work_02.HostedServices
{
    public class MigrationHostedService : IHostedService
    {
        private readonly IServiceProvider serviceProvider;
        public MigrationHostedService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();
            var svc = scope.ServiceProvider.GetRequiredService<ApplyMigrationService>();
            await svc.ApplyMigrationAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
