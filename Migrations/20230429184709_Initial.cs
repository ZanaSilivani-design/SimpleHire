using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleHire.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                });

            migrationBuilder.CreateTable(
                name: "Information",
                columns: table => new
                {
                    InfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearExp = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Information", x => x.InfoId);
                    table.ForeignKey(
                        name: "FK_Information_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "Name" },
                values: new object[,]
                {
                    { "Dev", "Software developers" },
                    { "Ele", "Electrician" },
                    { "Eng", "Engineering" },
                    { "Law", "Lawyer" },
                    { "Mar", "Marketing" },
                    { "Mec", "Mechanic" },
                    { "Nur", "Nurse" },
                    { "Tec", "Teacher" }
                });

            migrationBuilder.InsertData(
                table: "Information",
                columns: new[] { "InfoId", "Email", "JobId", "Major", "Name", "Phone", "YearExp" },
                values: new object[] { 1, "ZanaSilivani@gmail.com", "Dev", "Information System", "Zana Silivani", "615-693-7766", 5 });

            migrationBuilder.InsertData(
                table: "Information",
                columns: new[] { "InfoId", "Email", "JobId", "Major", "Name", "Phone", "YearExp" },
                values: new object[] { 2, "KarenSmith@gmail.com", "Nur", "Nursing", "Karen Smith", "615-693-7766", 10 });

            migrationBuilder.InsertData(
                table: "Information",
                columns: new[] { "InfoId", "Email", "JobId", "Major", "Name", "Phone", "YearExp" },
                values: new object[] { 3, "OsemaFalah@gmail.com", "Mar", "Information System", "Osema Falah", "615-693-7766", 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Information_JobId",
                table: "Information",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Information");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
