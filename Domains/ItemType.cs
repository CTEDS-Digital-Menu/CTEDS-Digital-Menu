using System.Collections.Generic;

namespace CTEDSDigitalMenu.Domains;

public class ItemType
{
    public int ItemTypeId { get; set; }

    public string? Name { get; set; }

    public ICollection<MenuItem> MenuItems { get; set; }
}
