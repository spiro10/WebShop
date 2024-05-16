
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Implementations
{
    public class UserQueueProcessorService : BackgroundService
    {
        private readonly IServiceScopeFactory scopeFactory;

        public UserQueueProcessorService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (stoppingToken.IsCancellationRequested)
            {
                using (var scope = scopeFactory.CreateScope())
                {
                    var accountService = scope.ServiceProvider.GetRequiredService<IAccountService>();
                    var newUsers = await accountService.GetRegUsers();

                    if (newUsers.Any())
                    {
                        foreach(var user in newUsers)
                        {
                            string test = $"novi korisnik {user.FirstName} {user.LastName} je dodan {user.RegistrationDate.GetValueOrDefault().ToShortDateString()}";
                            int count = 0;
                        }
                    }
                }

                await Task.Delay(1000, stoppingToken);


            }
        }
    }
}
