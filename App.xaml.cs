using CTEDSDigitalMenu.Contexts;
using CTEDSDigitalMenu.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CTEDSDigitalMenu;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
	private ServiceProvider serviceProvider;

	public App()
	{
		ServiceCollection services = new();

		services.AddDbContext<MenuContext>(options =>
		{
			options.UseSqlite("Data source = menu.db");
		});

		services.AddSingleton<MenuController>(x => new MenuController(x.GetService<MenuContext>()));
		services.AddSingleton<MainWindow>(x => new MainWindow(x.GetService<MenuController>()));
		serviceProvider = services.BuildServiceProvider();
	}

	private void OnStartup(object s, StartupEventArgs e)
	{
		var mainWindow = serviceProvider.GetService<MainWindow>();

		mainWindow?.Show();
	}

}
