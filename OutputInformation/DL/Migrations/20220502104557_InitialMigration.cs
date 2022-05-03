using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SerName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    House = table.Column<int>(type: "int", maxLength: 256, nullable: false),
                    Flat = table.Column<int>(type: "int", maxLength: 256, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Научно-исследовательский отдел" },
                    { 2, "Отдел технического контроля" },
                    { 3, "Конструкторский отдел" },
                    { 4, "Отдел изобретательства и патентирования" },
                    { 5, "Отдел маркетинговых исследований" },
                    { 6, "Инструментальный отдел" },
                    { 7, "Отдел главного технолога" },
                    { 8, "Отдел автоматизации" }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Главный конструктор" },
                    { 2, "Заведующий лабораторией" },
                    { 3, "Конструктор" },
                    { 4, "Лаборант" },
                    { 5, "Начальник отдела ИТ" },
                    { 6, "Системный администратор" },
                    { 7, "Старший программист" },
                    { 8, "Программист" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "DepartmentId", "Name", "Patronymic", "PositionId", "SerName", "Telephone" },
                values: new object[] { 1, 1, "Александр", "Генадьевич", 1, "Моркович", "29 134-56-89" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "DepartmentId", "Name", "Patronymic", "PositionId", "SerName", "Telephone" },
                values: new object[] { 2, 3, "Дмитрий", "Викторович", 5, "Шишко", "29 456-74-13" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "DepartmentId", "Name", "Patronymic", "PositionId", "SerName", "Telephone" },
                values: new object[] { 3, 5, "Анатолий", "Витальевич", 6, "Гаврилов", "29 117-36-78" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "EmployeeId", "Flat", "House", "Street" },
                values: new object[] { 1, 1, 20, 31, "Толстого" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "EmployeeId", "Flat", "House", "Street" },
                values: new object[] { 2, 2, 30, 20, "Аэродромная" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "EmployeeId", "Flat", "House", "Street" },
                values: new object[] { 3, 3, 100, 13, "Воронянского" });

            migrationBuilder.CreateIndex(
                name: "IX_Address_EmployeeId",
                table: "Address",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PositionId",
                table: "Employee",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
