using CTEDSDigitalMenu.Controllers;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CTEDSDigitalMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MenuController menuController;
        Models.MenuItem selectedItem = new();

        public MainWindow(MenuController menuController)
        {
            this.menuController = menuController;
            InitializeComponent();
            RenderEntries();
            RenderMain();
            RenderDesserts();
            RenderDrinks();
            Style rowStyle = new Style(typeof(ListBoxItem));
            rowStyle.Setters.Add(new EventSetter(ListBoxItem.MouseDoubleClickEvent, new MouseButtonEventHandler(Row_DoubleClick)));

            HttpServerController httpServer = new(menuController);
            ServerURI.Text = $"Servidor rodando no link (Local): http://{GetLocalIPAddress()}:2035/";
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
        public void ReRenderByType(Models.MenuItem Item)
        {
            if (Item.ItemTypeId == 1)
                RenderEntries();
            else if (Item.ItemTypeId == 2)
                RenderMain();
            else if (Item.ItemTypeId == 3)
                RenderDesserts();
            else if (Item.ItemTypeId == 4)
                RenderDrinks();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Views.AddWindow AddItemWin = new(menuController);
            AddItemWin.Show();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            selectedItem = (sender as FrameworkElement).DataContext as Models.MenuItem;
            Views.EditWindow EditItemWin = new(menuController, selectedItem);
            EditItemWin.Show();
        }

        public static string GetLocalIPAddress()
        {
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            return localIP;
        }
    }
}
