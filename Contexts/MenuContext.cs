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
        },
        new ItemType
        {
            ItemTypeId = 4,
            Name = "Bebida"
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasData(
                new MenuItem
                {
                    Name = "Casquinha de Siri",
                    Price = 23.99,
                    PhotoPath = "/Assets/casquinha_de_siri.jpg",
                    Description = "Siri desfiado e temperado servido em sua casca",
                    ItemTypeId = 1
                },
                new MenuItem
                {
                    Name = "Moqueca de Camarão",
                    Price = 54.99,
                    PhotoPath = "/Assets/moqueca_de_camarao.jpg",
                    Description = "Camarões refogados com leite de coco, pimentões, tomates e cebola",
                    ItemTypeId = 2
                },
                new MenuItem
                {
                    Name = "Brigadeiro de Colher",
                    Price = 18.99,
                    PhotoPath = "/Assets/brigadeiro_de_colher.jpg",
                    Description = "Brigadeiro cremoso de colher com farofa de paçoca",
                    ItemTypeId = 3
                },
                new MenuItem
                {
                    Name = "Creme de Abóbora",
                    Price = 18.99,
                    PhotoPath = "/Assets/creme_de_abobora.jpg",
                    Description = "Delicioso creme de abóbora com sementes e um toque de gengibre. Acompanha pão de alho crocante.",
                    ItemTypeId = 1
                }, new MenuItem
                {
                    Name = "Tábua de Frios",
                    Price = 39.99,
                    PhotoPath = "/Assets/tabua_de_frios.jpg",
                    Description = "Tábua de frios para compartilhar! Inclui salames, queijos e embutidos.",
                    ItemTypeId = 1
                }, new MenuItem
                {
                    Name = "Picanha Assada",
                    Price = 63.99,
                    PhotoPath = "/Assets/picanha_assada.jpg",
                    Description = "Picanha Assada na grelha no ponto escolhido! Acompanha farofa e vinagrete.",
                    ItemTypeId = 2
                }, new MenuItem
                {
                    Name = "Salada Caesar",
                    Price = 43.99,
                    PhotoPath = "/Assets/salada_caesar.jpg",
                    Description = "Deliciosa Salada Caesar com tiras de peito de frango e queijo parmesão ralado.",
                    ItemTypeId = 2
                }, new MenuItem
                {
                    Name = "Pudim",
                    Price = 22.99,
                    PhotoPath = "/Assets/pudim.jpg",
                    Description = "Delicioso pudim de leite com baunilha e calda de caramelo.",
                    ItemTypeId = 3
                }, new MenuItem
                {
                    Name = "Mousse de Chocolate",
                    Price = 19.99,
                    PhotoPath = "/Assets/mousse.jpg",
                    Description = "Mousse de chocolate leve e aerado.",
                    ItemTypeId = 3
                }, new MenuItem
                {
                    Name = "Refrigerante Refill",
                    Price = 14.99,
                    PhotoPath = "/Assets/refrigerante.jpg",
                    Description = "Refill de refrigerante para beber à vontade!",
                    ItemTypeId = 4
                }, new MenuItem
                {
                    Name = "Chá Gelado Refill",
                    Price = 14.99,
                    PhotoPath = "/Assets/cha.jpg",
                    Description = "Refill de chá gelado para beber à vontade!",
                    ItemTypeId = 4
                }, new MenuItem
                {
                    Name = "Chopp",
                    Price = 16.99,
                    PhotoPath = "/Assets/cerveja.jpg",
                    Description = "Chopp bem gelado!",
                    ItemTypeId = 4
                });
        });

        base.OnModelCreating(modelBuilder);
    }
}
