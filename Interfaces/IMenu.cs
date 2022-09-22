using CTEDSDigitalMenu.Domains;
using System.Collections.Generic;

namespace CTEDSDigitalMenu.Interfaces;

public interface IMenu
{
    List<MenuItem> List();

    MenuItem Create(MenuItem newMenuItem);

    void Delete(int menuItemId);
}
