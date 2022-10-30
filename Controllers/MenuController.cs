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

        public List<MenuItem> GetMenuItemsPerType(string itemtypename)
        {
            menuContext.ItemTypes?.ToList();

            return menuContext.MenuItems?.Where(item => item.ItemType.Name == itemtypename).ToList() ?? new List<MenuItem>();
        }

        public string GetTypeName(int typeId)
        {
            return menuContext.ItemTypes?.Single(item => item.ItemTypeId == typeId).Name ?? "";
        }

        public void Create(MenuItem newMenuItem)
        {
            menuContext.MenuItems?.Add(newMenuItem);
            menuContext.SaveChanges();
        }

        public void Delete(MenuItem menuItem)
        {
            MenuItem? itemToRemove = menuContext.MenuItems?.Find(menuItem);

            if (itemToRemove != null)
            {
                menuContext.MenuItems?.Remove(itemToRemove);
                menuContext.SaveChanges();
            }
        }

        public void Update(MenuItem menuItem)
        {
            menuContext.MenuItems?.Update(menuItem);
            menuContext.SaveChanges();
        }
    }
}
