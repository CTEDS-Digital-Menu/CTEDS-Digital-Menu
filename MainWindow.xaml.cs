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
            RenderDesserts();
        }

        private void RenderEntries()
        {
            Entries.ItemsSource = menuController.GetMenuItems();
        }
        private void RenderDesserts()
        {
            ListBoxDesserts.ItemsSource = menuController.GetMenuItems();
        }
    }
}
