using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationINSAT.Migrations
{
    /// <inheritdoc />
    public partial class testmig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Membershiptypes_MembershipId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MembershipId",
                table: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "MembershiptypesId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MembershiptypesId",
                table: "Customers",
                column: "MembershiptypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Membershiptypes_MembershiptypesId",
                table: "Customers",
                column: "MembershiptypesId",
                principalTable: "Membershiptypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Membershiptypes_MembershiptypesId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MembershiptypesId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MembershiptypesId",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MembershipId",
                table: "Customers",
                column: "MembershipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Membershiptypes_MembershipId",
                table: "Customers",
                column: "MembershipId",
                principalTable: "Membershiptypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
