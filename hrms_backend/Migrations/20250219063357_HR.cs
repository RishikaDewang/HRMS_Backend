using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace hrms_backend.Migrations
{
    /// <inheritdoc />
    public partial class HR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "GrossSalary",
                table: "Employee",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaidLeaves",
                table: "Employee",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Payrolls",
                columns: table => new
                {
                    PayrollId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    GrossSalary = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalLeaves = table.Column<int>(type: "integer", nullable: true),
                    HalfDayLeaves = table.Column<int>(type: "integer", nullable: true),
                    PaidLeaves = table.Column<int>(type: "integer", nullable: true),
                    ProfessionalTax = table.Column<decimal>(type: "numeric", nullable: true),
                    IncomeTax = table.Column<decimal>(type: "numeric", nullable: true),
                    Bonus = table.Column<decimal>(type: "numeric", nullable: true),
                    Adjustments = table.Column<decimal>(type: "numeric", nullable: true),
                    NetSalary = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payrolls", x => x.PayrollId);
                    table.ForeignKey(
                        name: "FK_Payrolls_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_EmployeeId",
                table: "Payrolls",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payrolls");

            migrationBuilder.DropColumn(
                name: "GrossSalary",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PaidLeaves",
                table: "Employee");
        }
    }
}
