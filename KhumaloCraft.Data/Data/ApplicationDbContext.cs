using KhumaloCraft.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KhumaloCraft.Data.Data
{
  public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<User> User { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      // Enforce unique constraint on the Email column in the User entity
      builder.Entity<User>()
        .HasIndex(u => u.Email)
        .IsUnique();

      builder.Entity<Order>()
        .HasOne(o => o.User)
        .WithMany()
        .HasForeignKey(o => o.UserId)
        .OnDelete(DeleteBehavior.Cascade);

      builder.Entity<Category>().HasData(
        new Category { CategoryId = 1, CategoryName = "Summer Collection" },
        new Category { CategoryId = 2, CategoryName = "Winter Collection" },
        new Category { CategoryId = 3, CategoryName = "Autumn Collection" },
        new Category { CategoryId = 4, CategoryName = "Spring Collection" }
      );

      builder.Entity<Product>().HasData(
        new Product { ProductId = 1, Name = "Naledi Gaze", Description = "Naledi Gaze is a stunning wooden sculpture of an owl, expertly carved from a single piece of a rich, dark wood Ebony. The artist’s attention to details brings the bird to life, from the delicate feathers to the piercings eyes.", Price = 1200.00m, ImageSrc = "https://iili.io/diXdT67.png", Quantity = 1, CategoryId = 1 },
        new Product { ProductId = 2, Name = "Whispering Wings", Description = "Whispering wings is a charming wooden sculpture of western screech-Owl, expertly carved from a single piece of soft, gray wood. The artist’s attention to details brings the small owl to life, as it perches quietly, its wings folded, exuding a sense of gentle wisdom.", Price = 1500.00m, ImageSrc = "https://iili.io/diXdAF9.png", Quantity = 1, CategoryId = 1 },
        new Product { ProductId = 3, Name = "Catnap", Description = "A cozy, Catnap is a captivating wooden sculpture of a cat gazing, expertly carved from a single piece of warm, golden wood. The artist’s attention to details brings the cat to life, from the delicate whiskers to the relaxed contented expression.", Price = 1000.00m, ImageSrc = "https://iili.io/diXdzn2.png", CategoryId = 1 },
        new Product { ProductId = 4, Name = "Hoppy Sindile", Description = "Hoppy Sindile is a delightful wooden sculpture of a kangaroo in mid-hop, expertly carved from a single piece of rich, Walnut wood. The artist’s attention to details brings the marsupial to life, from the powerful hind legs to the joyful, carefree expression.", Price = 1750.00m, ImageSrc = "https://iili.io/diXdIGS.png", Quantity = 1, CategoryId = 1 },
        new Product { ProductId = 5, Name = "Uhlanga Lwenyoni", Description = "This handcrafted wooden art piece, 'Uhlanga Lwenyoni,' showcases a captivating fusion of traditional African artistry and natural elegance. Skillfully carved from rich, durable wood, it features intricate tribal patterns and vibrant hand-painted accents.", Price = 1400.00m, ImageSrc = "https://iili.io/diXd58u.png", Quantity = 1, CategoryId = 1 },
        new Product { ProductId = 6, Name = "Azure Blue Jay Songster", Description = "Azure Blue Jay Songster is a vibrant wooden sculpture of a blue jay in mid-song, expertly carved from a single piece of rich, blue-stained wood. The artist’s attention to detail brings the bird to life from the intricate feathers to the joyful, open beak.", Price = 1500.00m, ImageSrc = "https://iili.io/diXdRae.png", Quantity = 1, CategoryId = 1 },
        new Product { ProductId = 7, Name = "Nightshade", Description = "Nightshade is a stunning wooden sculpture on an Owl grasping a branch, highlighting the bird's fierce strength and precision. The artist’s attention to detail brings the scene to life, from the owl’s wise eyes to the intricate texture of the branch.", Price = 1800.00m, ImageSrc = "https://iili.io/diXdauj.png", Quantity = 0, CategoryId = 1 },
        new Product { ProductId = 8, Name = "Playful Kid", Description = "Playful Kid is a charming wooden sculpture of a little goat, expertly carved from a single piece of warm, golden wood. The artist’s attention to details brings the playful goat to life, from its curious expression to its agile legs.", Price = 1300.00m, ImageSrc = "https://iili.io/diXd7yb.png", CategoryId = 1 },
        new Product { ProductId = 9, Name = "Dekeledi", Description = "Dekeledi is a playful wooden sculpture of a little rabbit, expertly carved from a single piece of soft, white pine wood. The artist's attention to details brings the humorous scene to life, as the rabbit appears stuck, its little legs stuck and eyes glazing.", Price = 1900.00m, ImageSrc = "https://iili.io/diXdcwx.png", Quantity = 1, CategoryId = 1 },
        new Product { ProductId = 10, Name = "Curios Curlew", Description = "Curios Curlew is a delightful wooden sculpture of a bird with its long nose, expertly carved from a single piece of warm, golden wood. The artist's attention to details brings life to the bird, as it sniffs and explores its surroundings with its uniquely shaped beak.", Price = 1200.00m, ImageSrc = "https://iili.io/diXdlZQ.png", Quantity = 1, CategoryId = 1 },
        new Product { ProductId = 11, Name = "Bombastic Glance", Description = "Bombastic Glance is a captivating wooden sculpture of a partridge bird, expertly carved from a single piece of warm, golden wood. The artist's attention to details brings the bird to life, as it turns its head away, lost in thought.", Price = 1600.00m, ImageSrc = "https://iili.io/diXd1nV.png", CategoryId = 0 },
        new Product { ProductId = 12, Name = "Moonlight Guardian", Description = "Moonlight Guardian is a majestic wooden sculpture of the Great Horned Owl, expertly carved from a single piece of rich, white wood. The artist’s attention to detail brings the powerful bird to life, as it stands watchful and wise, bathed in the soft glow of the moon.", Price = 1600.00m, ImageSrc = "https://iili.io/diXdEMB.png", Quantity = 0, CategoryId = 1 },
        new Product { ProductId = 13, Name = "Sightless Peace", Description = "Sightless Peace is a thought-provoking wooden sculpture of a doll with no eyes. Carved from a single piece of smooth, pale wood. The artist’s attention to details brings the doll to life, despite its lack of eyes, conveying a sense of peacefulness and inner sight.", Price = 1150.00m, ImageSrc = "https://iili.io/diXdVF1.png", Quantity = 1, CategoryId = 1 },
        new Product { ProductId = 14, Name = "Fluffy Friend", Description = "Fluffy Friend is a delightful wooden sculpture of a little rabbit, expertly carved from a single piece of soft, white Basswood. The artist’s attention to details brings the adorable rabbit to life, from its twitching whiskers to its cuddly, rounded body.", Price = 1240.00m, ImageSrc = "https://iili.io/diXdWcF.png", Quantity = 1, CategoryId = 1 },
        new Product { ProductId = 15, Name = "Wise Madala", Description = "Wise Madala is a majestic wooden sculpture of an old owl, carved from a single piece of rich dark wood. The artist's attention to details brings the wise bird to life, from its knowing gaze to its weathered, aged feathers.", Price = 1190.00m, ImageSrc = "https://iili.io/diXdX8g.png", Quantity = 1, CategoryId = 1 }
      );

      builder.Entity<Cart>()
        .HasKey(c => c.CartId);

      builder.Entity<Cart>()
        .HasMany(c => c.Items)
        .WithOne(ci => ci.Cart)
        .HasForeignKey(ci => ci.CartId);

      builder.Entity<CartItem>()
        .Property(c => c.Price)
        .HasColumnType("decimal(18,4)");
    }
  }
}