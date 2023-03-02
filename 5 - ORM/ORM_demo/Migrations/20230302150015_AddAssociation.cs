using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORM_demo.Migrations
{
    public partial class AddAssociation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Association",
                columns: table => new
                {
                    AssocciationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Association", x => x.AssocciationId);
                });

            migrationBuilder.CreateTable(
                name: "AssociationCustomer",
                columns: table => new
                {
                    AssociationsAssocciationId = table.Column<int>(type: "int", nullable: false),
                    CustomersCustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociationCustomer", x => new { x.AssociationsAssocciationId, x.CustomersCustomerId });
                    table.ForeignKey(
                        name: "FK_AssociationCustomer_Association_AssociationsAssocciationId",
                        column: x => x.AssociationsAssocciationId,
                        principalTable: "Association",
                        principalColumn: "AssocciationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssociationCustomer_Customer_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssociationCustomer_CustomersCustomerId",
                table: "AssociationCustomer",
                column: "CustomersCustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssociationCustomer");

            migrationBuilder.DropTable(
                name: "Association");
        }
    }
}
