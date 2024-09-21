using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KhumaloCraft.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    passwordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImageSrc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Summer Collection" },
                    { 2, "Winter Collection" },
                    { 3, "Autumn Collection" },
                    { 4, "Spring Collection" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImageSrc", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Naledi Gaze is a stunning wooden sculpture of an owl, expertly carved from a single piece of a rich, dark wood Ebony. The artist’s attention to details brings the bird to life, from the delicate feathers to the piercings eyes.", "https://iili.io/diXdT67.png", "Naledi Gaze", 1200.00m },
                    { 2, 1, "Whispering wings is a charming wooden sculpture of western screech-Owl, expertly carved from a single piece of soft, gray wood. The artist’s attention to details brings the small owl to life, as it perches quietly, its wings folded, exuding a sense of gentle wisdom.", "https://iili.io/diXdAF9.png", "Whispering Wings", 1500.00m },
                    { 3, 1, "A cozy, Catnap is a captivating wooden sculpture of a cat gazing, expertly carved from a single piece of warm, golden wood. The artist’s attention to details brings the cat to life, from the delicate whiskers to the relaxed contented expression.", "https://iili.io/diXdzn2.png", "Catnap", 1000.00m },
                    { 4, 1, "Hoppy Sindile is a delightful wooden sculpture of a kangaroo in mid-hop, expertly carved from a single piece of rich, Walnut wood. The artist’s attention to details brings the marsupial to life, from the powerful hind legs to the joyful, carefree expression.", "https://iili.io/diXdIGS.png", "Hoppy Sindile", 1750.00m },
                    { 5, 1, "This handcrafted wooden art piece, 'Uhlanga Lwenyoni,' showcases a captivating fusion of traditional African artistry and natural elegance. Skillfully carved from rich, durable wood, it features intricate tribal patterns and vibrant hand-painted accents.", "https://iili.io/diXd58u.png", "Uhlanga Lwenyoni", 1400.00m },
                    { 6, 1, "Azure Blue Jay Songster is a vibrant wooden sculpture of a blue jay in mid-song, expertly carved from a single piece of rich, blue-stained wood. The artist’s attention to detail brings the bird to life from the intricate feathers to the joyful, open beak.", "https://iili.io/diXdRae.png", "Azure Blue Jay Songster", 1500.00m },
                    { 7, 1, "Nightshade is a stunning wooden sculpture on an Owl grasping a branch, highlighting the bird's fierce strength and precision. The artist’s attention to detail brings the scene to life, from the owl’s wise eyes to the intricate texture of the branch.", "https://iili.io/diXdauj.png", "Nightshade", 1800.00m },
                    { 8, 1, "Playful Kid is a charming wooden sculpture of a little goat, expertly carved from a single piece of warm, golden wood. The artist’s attention to details brings the playful goat to life, from its curious expression to its agile legs.", "https://iili.io/diXd7yb.png", "Playful Kid", 300.00m },
                    { 9, 1, "Dekeledi is a playful wooden sculpture of a little rabbit, expertly carved from a single piece of soft, white pine wood. The artist's attention to details brings the humorous scene to life, as the rabbit appears stuck, its little legs stuck and eyes glazing.", "https://iili.io/diXdcwx.png", "Dekeledi", 1900.00m },
                    { 10, 1, "Curios Curlew is a delightful wooden sculpture of a bird with its long nose, expertly carved from a single piece of warm, golden wood. The artist's attention to details brings life to the bird, as it sniffs and explores its surroundings with its uniquely shaped beak.", "https://iili.io/diXdlZQ.png", "Curios Curlew", 1200.00m },
                    { 11, 1, "Bombastic Glance is a captivating wooden sculpture of a partridge bird, expertly carved from a single piece of warm, golden wood. The artist's attention to details brings the bird to life, as it turns its head away, lost in thought.", "https://iili.io/diXd1nV.png", "Bombastic Glance", 600.00m },
                    { 12, 1, "Moonlight Guardian is a majestic wooden sculpture of the Great Horned Owl, expertly carved from a single piece of rich, white wood. The artist’s attention to detail brings the powerful bird to life, as it stands watchful and wise, bathed in the soft glow of the moon.", "https://iili.io/diXdEMB.png", "Moonlight Guardian", 60.00m },
                    { 13, 1, "Sightless Peace is a thought-provoking wooden sculpture of a doll with no eyes. Carved from a single piece of smooth, pale wood. The artist’s attention to details brings the doll to life, despite its lack of eyes, conveying a sense of peacefulness and inner sight.", "https://iili.io/diXdVF1.png", "Sightless Peace", 1150.00m },
                    { 14, 1, "Fluffy Friend is a delightful wooden sculpture of a little rabbit, expertly carved from a single piece of soft, white Basswood. The artist’s attention to details brings the adorable rabbit to life, from its twitching whiskers to its cuddly, rounded body.", "https://iili.io/diXdWcF.png", "Fluffy Friend", 1240.00m },
                    { 15, 1, "Wise Madala is a majestic wooden sculpture of an old owl, carved from a single piece of rich dark wood. The artist's attention to details brings the wise bird to life, from its knowing gaze to its weathered, aged feathers.", "https://iili.io/diXdX8g.png", "Wise Madala", 1190.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
