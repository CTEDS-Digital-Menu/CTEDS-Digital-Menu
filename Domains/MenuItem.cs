namespace CTEDSDigitalMenu.Domains;

public class MenuItem
{
    public int MenuItemId { get; set; }

    public string? Name { get; set; }

    public double Price { get; set; }

    public string? Description { get; set; }

    public int ItemTypeId { get; set; }
    public ItemType ItemType { get; set; }
}


