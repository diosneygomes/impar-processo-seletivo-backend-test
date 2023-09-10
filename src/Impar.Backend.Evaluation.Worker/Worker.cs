using Impar.BackEnd.Evaluation.Application.Interfaces;

namespace Impar.Backend.Evaluation.Worker
{
    public class Worker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public Worker(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            await DoWorkAsync(stoppingToken);
        }

        private async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            using IServiceScope scope = _serviceProvider
                .CreateScope();

            var _service = scope.ServiceProvider
                .GetRequiredService<IMessageApplication>();

            while (!stoppingToken.IsCancellationRequested)
            {
                await _service
                    .ReceiveMessageAsync();

                await Task
                    .Delay(
                        1000,
                        stoppingToken);
            }
        }
    }
}