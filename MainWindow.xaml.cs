using CTEDSDigitalMenu.Controllers;
using System.Windows;

namespace CTEDSDigitalMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MenuController menuController;

        public MainWindow(MenuController menuController)
        {
            this.menuController = menuController;
            InitializeComponent();
            RenderEntries();
            RenderMain();
            RenderDesserts();
            RenderDrinks();
        }

        private void RenderEntries()
        {
            ListBoxEntries.ItemsSource = menuController.GetMenuItemsPerType("Entrada");
        }
        private void RenderMain()
        {
            ListBoxMain.ItemsSource = menuController.GetMenuItemsPerType("Principal");
        }
        private void RenderDesserts()
        {
            ListBoxDesserts.ItemsSource = menuController.GetMenuItemsPerType("Sobremesa");
        }
        private void RenderDrinks()
        {
            ListBoxDrinks.ItemsSource = menuController.GetMenuItemsPerType("Bebida");
        }
    }
}
