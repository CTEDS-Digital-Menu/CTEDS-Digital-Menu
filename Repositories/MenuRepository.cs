using CTEDSDigitalMenu.Contexts;
using CTEDSDigitalMenu.Domains;
using CTEDSDigitalMenu.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CTEDSDigitalMenu.Repositories;

public class MenuRepository : IMenu
{
    public List<MenuItem> List()
    {
        using (var ctx = new Context())
        {
            ctx.ItemTypes.ToList();

            return ctx.MenuItems.ToList();
        }
    }

    public MenuItem Create(MenuItem newMenuItem)
    {
        throw new NotImplementedException();
    }

    public void Delete(int menuItemId)
    {
        throw new NotImplementedException();
    }
}
