using CTEDSDigitalMenu.Models;
using Microsoft.EntityFrameworkCore;

namespace CTEDSDigitalMenu.Contexts;
public class MenuContext : DbContext
{
    public DbSet<ItemType>? ItemTypes { get; set; }

    public DbSet<MenuItem>? MenuItems { get; set; }

    public MenuContext(DbContextOptions<MenuContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemType>().HasData(
        new ItemType
        {
            ItemTypeId = 1,
            Name = "Entrada"
        },
        new ItemType
        {
            ItemTypeId = 2,
            Name = "Principal"
        },
        new ItemType
        {
            ItemTypeId = 3,
            Name = "Sobremesa"
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasData(
                new MenuItem
                {
                    MenuItemId = 1,
                    Name = "Casquinha de Siri",
                    Price = 23.99,
                    Description = "Siri desfiado e temperado servido em sua casca",
                    ItemTypeId = 1
                },
                new MenuItem
                {
                    MenuItemId = 2,
                    Name = "Moqueca de Camarão",
                    Price = 54.99,
                    Description = "Camatões refogados com leite de coco, pimentões, tomates e cebola",
                    ItemTypeId = 2
                },
                new MenuItem
                {
                    MenuItemId = 3,
                    Name = "Brigadeiro de Colher",
                    Price = 18.99,
                    Description = "Brigadeiro cremoso de colher com farofa de paçoca",
                    ItemTypeId = 3
                });
        });

        base.OnModelCreating(modelBuilder);
    }
}
