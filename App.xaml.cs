using CTEDSDigitalMenu.Contexts;
using CTEDSDigitalMenu.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
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

		services.AddSingleton<MainWindow>();

		serviceProvider = services.BuildServiceProvider();

		var menuItems = serviceProvider.GetService<MenuContext>()?.GetMenuItems() ?? new System.Collections.Generic.List<MenuItem>();



		foreach (var item in menuItems)
		{
			Debug.WriteLine($"{item.MenuItemId} {item.Name} {item.Price} {item.Description} {item.ItemTypeId} {item.ItemType?.Name}");
		}

	}

	private void OnStartup(object s, StartupEventArgs e)
	{
		var mainWindow = serviceProvider.GetService<MainWindow>();

		mainWindow?.Show();
	}

}
