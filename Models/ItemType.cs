using System.Collections.Generic;

namespace CTEDSDigitalMenu.Models;

public class ItemType
{
    public int ItemTypeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<MenuItem>? MenuItems { get; set; }
}
