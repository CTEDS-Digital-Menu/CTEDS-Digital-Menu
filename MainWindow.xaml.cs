using CTEDSDigitalMenu.Repositories;
using System.Diagnostics;
using System.Windows;

namespace CTEDSDigitalMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MenuRepository menuRepository;

        public MainWindow()
        {
            InitializeComponent();

            menuRepository = new MenuRepository();

            DataContext = this;

            foreach (var item in menuRepository.List())
            {
                Debug.WriteLine($"{item.MenuItemId} {item.Name} {item.Price} {item.Description} {item.ItemTypeId} {item.ItemType?.Name}");
            }


        }
    }
}
