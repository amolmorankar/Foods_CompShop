using Microsoft.EntityFrameworkCore.Migrations;

namespace Foods_CompShop.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompShop",
                columns: table => new
                {
                    CompShopId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dept = table.Column<string>(nullable: true),
                    ItemNo = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WHSE = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    MAC = table.Column<string>(nullable: true),
                    Sell = table.Column<string>(nullable: true),
                    IMU = table.Column<string>(nullable: true),
                    FutureSellPrice = table.Column<string>(nullable: true),
                    FutureSellDate = table.Column<string>(nullable: true),
                    LowestComp = table.Column<string>(nullable: true),
                    MaxPrice = table.Column<string>(nullable: true),
                    NewSell = table.Column<string>(nullable: true),
                    NewPrice = table.Column<string>(nullable: true),
                    SamsConvPrice = table.Column<string>(nullable: true),
                    SamsShelfPrice = table.Column<string>(nullable: true),
                    SamsAddtnPrice = table.Column<string>(nullable: true),
                    SamsShoppedURL = table.Column<string>(nullable: true),
                    SamsShoppedZip = table.Column<string>(nullable: true),
                    BJsConvPrice = table.Column<string>(nullable: true),
                    BJsShelfPrice = table.Column<string>(nullable: true),
                    BJsAddtnPrice = table.Column<string>(nullable: true),
                    BJsShoppedURL = table.Column<string>(nullable: true),
                    BJsShoppedZip = table.Column<string>(nullable: true),
                    BuyerNo = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    BuyerComments = table.Column<string>(nullable: true),
                    PulledDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompShop", x => x.CompShopId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompShop");
        }
    }
}
