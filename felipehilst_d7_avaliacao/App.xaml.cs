using felipehilst_d7_avaliacao.Data;
using felipehilst_d7_avaliacao.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace felipehilst_d7_avaliacao
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new();

            services.AddDbContext<LoginAppContext>(options =>
            {
                options.UseSqlite("Data Source=User.db");
            });

            services.AddSingleton<ILoginService, LoginService>();
            services.AddSingleton<MainWindow>();

            serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            if (mainWindow == null) throw new Exception("Missing Main Window");

            var loginService = serviceProvider.GetService<ILoginService>();
            mainWindow.loginService = loginService;

            mainWindow.Show();
        }
    }
}
