﻿// <auto-generated />
using System;
using KhumaloCraft.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KhumaloCraft.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KhumaloCraft.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Summer Collection"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Winter Collection"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Autumn Collection"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Spring Collection"
                        });
                });

            modelBuilder.Entity("KhumaloCraft.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("KhumaloCraft.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("KhumaloCraft.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            Description = "Naledi Gaze is a stunning wooden sculpture of an owl, expertly carved from a single piece of a rich, dark wood Ebony. The artist’s attention to details brings the bird to life, from the delicate feathers to the piercings eyes.",
                            ImageSrc = "https://iili.io/diXdT67.png",
                            Name = "Naledi Gaze",
                            Price = 1200.00m
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            Description = "Whispering wings is a charming wooden sculpture of western screech-Owl, expertly carved from a single piece of soft, gray wood. The artist’s attention to details brings the small owl to life, as it perches quietly, its wings folded, exuding a sense of gentle wisdom.",
                            ImageSrc = "https://iili.io/diXdAF9.png",
                            Name = "Whispering Wings",
                            Price = 1500.00m
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 1,
                            Description = "A cozy, Catnap is a captivating wooden sculpture of a cat gazing, expertly carved from a single piece of warm, golden wood. The artist’s attention to details brings the cat to life, from the delicate whiskers to the relaxed contented expression.",
                            ImageSrc = "https://iili.io/diXdzn2.png",
                            Name = "Catnap",
                            Price = 1000.00m
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 1,
                            Description = "Hoppy Sindile is a delightful wooden sculpture of a kangaroo in mid-hop, expertly carved from a single piece of rich, Walnut wood. The artist’s attention to details brings the marsupial to life, from the powerful hind legs to the joyful, carefree expression.",
                            ImageSrc = "https://iili.io/diXdIGS.png",
                            Name = "Hoppy Sindile",
                            Price = 1750.00m
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 1,
                            Description = "This handcrafted wooden art piece, 'Uhlanga Lwenyoni,' showcases a captivating fusion of traditional African artistry and natural elegance. Skillfully carved from rich, durable wood, it features intricate tribal patterns and vibrant hand-painted accents.",
                            ImageSrc = "https://iili.io/diXd58u.png",
                            Name = "Uhlanga Lwenyoni",
                            Price = 1400.00m
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 1,
                            Description = "Azure Blue Jay Songster is a vibrant wooden sculpture of a blue jay in mid-song, expertly carved from a single piece of rich, blue-stained wood. The artist’s attention to detail brings the bird to life from the intricate feathers to the joyful, open beak.",
                            ImageSrc = "https://iili.io/diXdRae.png",
                            Name = "Azure Blue Jay Songster",
                            Price = 1500.00m
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 1,
                            Description = "Nightshade is a stunning wooden sculpture on an Owl grasping a branch, highlighting the bird's fierce strength and precision. The artist’s attention to detail brings the scene to life, from the owl’s wise eyes to the intricate texture of the branch.",
                            ImageSrc = "https://iili.io/diXdauj.png",
                            Name = "Nightshade",
                            Price = 1800.00m
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 1,
                            Description = "Playful Kid is a charming wooden sculpture of a little goat, expertly carved from a single piece of warm, golden wood. The artist’s attention to details brings the playful goat to life, from its curious expression to its agile legs.",
                            ImageSrc = "https://iili.io/diXd7yb.png",
                            Name = "Playful Kid",
                            Price = 300.00m
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 1,
                            Description = "Dekeledi is a playful wooden sculpture of a little rabbit, expertly carved from a single piece of soft, white pine wood. The artist's attention to details brings the humorous scene to life, as the rabbit appears stuck, its little legs stuck and eyes glazing.",
                            ImageSrc = "https://iili.io/diXdcwx.png",
                            Name = "Dekeledi",
                            Price = 1900.00m
                        },
                        new
                        {
                            ProductId = 10,
                            CategoryId = 1,
                            Description = "Curios Curlew is a delightful wooden sculpture of a bird with its long nose, expertly carved from a single piece of warm, golden wood. The artist's attention to details brings life to the bird, as it sniffs and explores its surroundings with its uniquely shaped beak.",
                            ImageSrc = "https://iili.io/diXdlZQ.png",
                            Name = "Curios Curlew",
                            Price = 1200.00m
                        },
                        new
                        {
                            ProductId = 11,
                            CategoryId = 1,
                            Description = "Bombastic Glance is a captivating wooden sculpture of a partridge bird, expertly carved from a single piece of warm, golden wood. The artist's attention to details brings the bird to life, as it turns its head away, lost in thought.",
                            ImageSrc = "https://iili.io/diXd1nV.png",
                            Name = "Bombastic Glance",
                            Price = 600.00m
                        },
                        new
                        {
                            ProductId = 12,
                            CategoryId = 1,
                            Description = "Moonlight Guardian is a majestic wooden sculpture of the Great Horned Owl, expertly carved from a single piece of rich, white wood. The artist’s attention to detail brings the powerful bird to life, as it stands watchful and wise, bathed in the soft glow of the moon.",
                            ImageSrc = "https://iili.io/diXdEMB.png",
                            Name = "Moonlight Guardian",
                            Price = 60.00m
                        },
                        new
                        {
                            ProductId = 13,
                            CategoryId = 1,
                            Description = "Sightless Peace is a thought-provoking wooden sculpture of a doll with no eyes. Carved from a single piece of smooth, pale wood. The artist’s attention to details brings the doll to life, despite its lack of eyes, conveying a sense of peacefulness and inner sight.",
                            ImageSrc = "https://iili.io/diXdVF1.png",
                            Name = "Sightless Peace",
                            Price = 1150.00m
                        },
                        new
                        {
                            ProductId = 14,
                            CategoryId = 1,
                            Description = "Fluffy Friend is a delightful wooden sculpture of a little rabbit, expertly carved from a single piece of soft, white Basswood. The artist’s attention to details brings the adorable rabbit to life, from its twitching whiskers to its cuddly, rounded body.",
                            ImageSrc = "https://iili.io/diXdWcF.png",
                            Name = "Fluffy Friend",
                            Price = 1240.00m
                        },
                        new
                        {
                            ProductId = 15,
                            CategoryId = 1,
                            Description = "Wise Madala is a majestic wooden sculpture of an old owl, carved from a single piece of rich dark wood. The artist's attention to details brings the wise bird to life, from its knowing gaze to its weathered, aged feathers.",
                            ImageSrc = "https://iili.io/diXdX8g.png",
                            Name = "Wise Madala",
                            Price = 1190.00m
                        });
                });

            modelBuilder.Entity("KhumaloCraft.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("passwordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("KhumaloCraft.Models.Order", b =>
                {
                    b.HasOne("KhumaloCraft.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KhumaloCraft.Models.OrderItem", b =>
                {
                    b.HasOne("KhumaloCraft.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KhumaloCraft.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KhumaloCraft.Models.Product", b =>
                {
                    b.HasOne("KhumaloCraft.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
