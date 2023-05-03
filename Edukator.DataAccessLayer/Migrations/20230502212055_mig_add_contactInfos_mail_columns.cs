using Microsoft.EntityFrameworkCore.Migrations;

namespace Edukator.DataAccessLayer.Migrations
{
    public partial class mig_add_contactInfos_mail_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mail1",
                table: "ContactInfos",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mail2",
                table: "ContactInfos",
                type: "nvarchar(60)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mail1",
                table: "ContactInfos");

            migrationBuilder.DropColumn(
                name: "Mail2",
                table: "ContactInfos");
        }
    }
}
