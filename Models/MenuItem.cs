namespace CTEDSDigitalMenu.Models;

public class MenuItem
{
    public int MenuItemId { get; set; }

    public string Name { get; set; } = string.Empty;

    public double Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public string PhotoPath { get; set; } = string.Empty;

    public int ItemTypeId { get; set; }
    public ItemType? ItemType { get; set; }

}


