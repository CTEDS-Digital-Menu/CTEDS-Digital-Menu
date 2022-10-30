using CTEDSDigitalMenu.Controllers;
using CTEDSDigitalMenu.Models;
using System.Windows;

namespace CTEDSDigitalMenu.Views
{
    /// <summary>
    /// Lógica interna para Window1.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private readonly MenuController menuController;
        MenuItem newItem = new();

        public AddWindow(MenuController menuController)
        {
            this.menuController = menuController;
            InitializeComponent();
            NewItemGrid.DataContext = newItem;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            menuController.Create(newItem);
            MenuItem NewItem = new();
            NewItemGrid.DataContext = NewItem;
            this.Close();
            MessageBox.Show("Produto adicionado");
            ((MainWindow)System.Windows.Application.Current.MainWindow).ReRenderByType(NewItem);
        }
    }
}