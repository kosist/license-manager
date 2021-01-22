using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangedTableNameToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductChange_Type_ProductId",
                table: "ProductChange");

            migrationBuilder.DropForeignKey(
                name: "FK_Type_EmergencyKey_EmergencyKeyId",
                table: "Type");

            migrationBuilder.DropForeignKey(
                name: "FK_Type_License_LicenseId",
                table: "Type");

            migrationBuilder.DropForeignKey(
                name: "FK_Type_ProductMeta_ProductMetadataId",
                table: "Type");

            migrationBuilder.DropForeignKey(
                name: "FK_Type_Projects_ProjectId",
                table: "Type");

            migrationBuilder.DropForeignKey(
                name: "FK_ViProtection_Type_ProductId",
                table: "ViProtection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Type",
                table: "Type");

            migrationBuilder.RenameTable(
                name: "Type",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Type_ProjectId",
                table: "Products",
                newName: "IX_Products_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Type_ProductMetadataId",
                table: "Products",
                newName: "IX_Products_ProductMetadataId");

            migrationBuilder.RenameIndex(
                name: "IX_Type_LicenseId",
                table: "Products",
                newName: "IX_Products_LicenseId");

            migrationBuilder.RenameIndex(
                name: "IX_Type_EmergencyKeyId",
                table: "Products",
                newName: "IX_Products_EmergencyKeyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductChange_Products_ProductId",
                table: "ProductChange",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_EmergencyKey_EmergencyKeyId",
                table: "Products",
                column: "EmergencyKeyId",
                principalTable: "EmergencyKey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_License_LicenseId",
                table: "Products",
                column: "LicenseId",
                principalTable: "License",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductMeta_ProductMetadataId",
                table: "Products",
                column: "ProductMetadataId",
                principalTable: "ProductMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Projects_ProjectId",
                table: "Products",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ViProtection_Products_ProductId",
                table: "ViProtection",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductChange_Products_ProductId",
                table: "ProductChange");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_EmergencyKey_EmergencyKeyId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_License_LicenseId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductMeta_ProductMetadataId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Projects_ProjectId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ViProtection_Products_ProductId",
                table: "ViProtection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Type");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProjectId",
                table: "Type",
                newName: "IX_Type_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductMetadataId",
                table: "Type",
                newName: "IX_Type_ProductMetadataId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_LicenseId",
                table: "Type",
                newName: "IX_Type_LicenseId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_EmergencyKeyId",
                table: "Type",
                newName: "IX_Type_EmergencyKeyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Type",
                table: "Type",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductChange_Type_ProductId",
                table: "ProductChange",
                column: "ProductId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Type_EmergencyKey_EmergencyKeyId",
                table: "Type",
                column: "EmergencyKeyId",
                principalTable: "EmergencyKey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Type_License_LicenseId",
                table: "Type",
                column: "LicenseId",
                principalTable: "License",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Type_ProductMeta_ProductMetadataId",
                table: "Type",
                column: "ProductMetadataId",
                principalTable: "ProductMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Type_Projects_ProjectId",
                table: "Type",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ViProtection_Type_ProductId",
                table: "ViProtection",
                column: "ProductId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
