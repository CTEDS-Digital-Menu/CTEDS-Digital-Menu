using CTEDSDigitalMenu.Controllers;
using CTEDSDigitalMenu.Models;
using System.Windows;

namespace CTEDSDigitalMenu.Views
{
    /// <summary>
    /// Lógica interna para Window1.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private readonly MenuController menuController;
        MenuItem selectedItem = new();

        public EditWindow(MenuController menuController, MenuItem menuItem)
        {
            this.menuController = menuController;
            this.selectedItem = menuItem;
            InitializeComponent();
            EditItemGrid.DataContext = menuItem;
        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {
            menuController.Update(selectedItem);
            MessageBox.Show("Produto editado com sucesso");
            this.Close();
            ((MainWindow)System.Windows.Application.Current.MainWindow).ReRenderByType(selectedItem);

        }
        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Confirme para deletar item: " + selectedItem.Name, "Deletar", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                menuController.Delete(selectedItem);
                MessageBox.Show("Produto deletado com sucesso");
                this.Close();
                ((MainWindow)System.Windows.Application.Current.MainWindow).ReRenderByType(selectedItem);
            }
        }
    }
}