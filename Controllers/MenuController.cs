using CTEDSDigitalMenu.Contexts;
using CTEDSDigitalMenu.Models;
using System.Collections.Generic;
using System.Linq;

namespace CTEDSDigitalMenu.Controllers
{
    public class MenuController
    {
        private MenuContext menuContext;
        public MenuController(MenuContext context)
        {
            menuContext = context;
        }

        public List<MenuItem> GetMenuItems()
        {
            menuContext.ItemTypes?.ToList();

            return menuContext.MenuItems?.ToList() ?? new List<MenuItem>();
        }

        public void Create(MenuItem newMenuItem)
        {
            menuContext.MenuItems?.Add(newMenuItem);

            menuContext.SaveChanges();
        }

        public void Delete(int menuItemId)
        {
            MenuItem? itemToRemove = menuContext.MenuItems?.Find(menuItemId);

            if (itemToRemove != null)
            {
                menuContext.MenuItems?.Remove(itemToRemove);
                menuContext.SaveChanges();
            }
        }
    }
}
