using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApprovalStatus",
                columns: table => new
                {
                    idApprovalStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalStatus", x => x.idApprovalStatus);
                });

            migrationBuilder.CreateTable(
                name: "ExecutionStatus",
                columns: table => new
                {
                    idExecutionStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutionStatus", x => x.idExecutionStatus);
                });

            migrationBuilder.CreateTable(
                name: "TicketBody",
                columns: table => new
                {
                    idTicketBody = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    file = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketBody", x => x.idTicketBody);
                });

            migrationBuilder.CreateTable(
                name: "TicketCategory",
                columns: table => new
                {
                    idCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reqApproval = table.Column<bool>(type: "bit", nullable: false),
                    dateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketCategory", x => x.idCategory);
                });

            migrationBuilder.CreateTable(
                name: "TicketPriority",
                columns: table => new
                {
                    idPriority = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPriority", x => x.idPriority);
                });

            migrationBuilder.CreateTable(
                name: "TicketStatus",
                columns: table => new
                {
                    idStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketStatus", x => x.idStatus);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    idTicket = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idStatus = table.Column<int>(type: "int", nullable: false),
                    idExecutionStatus = table.Column<int>(type: "int", nullable: false),
                    idPriority = table.Column<int>(type: "int", nullable: false),
                    idTicketCategory = table.Column<int>(type: "int", nullable: false),
                    idUserExecutor = table.Column<int>(type: "int", nullable: false),
                    idAprovvaStatus = table.Column<int>(type: "int", nullable: false),
                    idTicketBody = table.Column<int>(type: "int", nullable: false),
                    minApproveReq = table.Column<int>(type: "int", nullable: false),
                    countOpen = table.Column<int>(type: "int", nullable: false),
                    countDisapproved = table.Column<int>(type: "int", nullable: false),
                    countApproved = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.idTicket);
                    table.ForeignKey(
                        name: "FK_Ticket_ApprovalStatus_idAprovvaStatus",
                        column: x => x.idAprovvaStatus,
                        principalTable: "ApprovalStatus",
                        principalColumn: "idApprovalStatus",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_ExecutionStatus_idExecutionStatus",
                        column: x => x.idExecutionStatus,
                        principalTable: "ExecutionStatus",
                        principalColumn: "idExecutionStatus",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_TicketBody_idTicketBody",
                        column: x => x.idTicketBody,
                        principalTable: "TicketBody",
                        principalColumn: "idTicketBody",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_TicketCategory_idTicketCategory",
                        column: x => x.idTicketCategory,
                        principalTable: "TicketCategory",
                        principalColumn: "idCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_TicketPriority_idPriority",
                        column: x => x.idPriority,
                        principalTable: "TicketPriority",
                        principalColumn: "idPriority",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_TicketStatus_idStatus",
                        column: x => x.idStatus,
                        principalTable: "TicketStatus",
                        principalColumn: "idStatus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketComment",
                columns: table => new
                {
                    idComment = table.Column<int>(type: "int", nullable: false),
                    idTicket = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateComment = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketComment", x => x.idComment);
                    table.ForeignKey(
                        name: "FK_TicketComment_Ticket_idComment",
                        column: x => x.idComment,
                        principalTable: "Ticket",
                        principalColumn: "idTicket",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketLog",
                columns: table => new
                {
                    idTicketLog = table.Column<int>(type: "int", nullable: false),
                    idTicket = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idUserCategory = table.Column<int>(type: "int", nullable: false),
                    dateHistory = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idAction = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketLog", x => x.idTicketLog);
                    table.ForeignKey(
                        name: "FK_TicketLog_Ticket_idTicketLog",
                        column: x => x.idTicketLog,
                        principalTable: "Ticket",
                        principalColumn: "idTicket",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketReceptors",
                columns: table => new
                {
                    idTicketReceptors = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idTicket = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketReceptors", x => x.idTicketReceptors);
                    table.ForeignKey(
                        name: "FK_TicketReceptors_Ticket_idTicketReceptors",
                        column: x => x.idTicketReceptors,
                        principalTable: "Ticket",
                        principalColumn: "idTicket",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketAction",
                columns: table => new
                {
                    idAction = table.Column<int>(type: "int", nullable: false),
                    actionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAction", x => x.idAction);
                    table.ForeignKey(
                        name: "FK_TicketAction_TicketLog_idAction",
                        column: x => x.idAction,
                        principalTable: "TicketLog",
                        principalColumn: "idTicketLog",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApprovalStatus",
                columns: new[] { "idApprovalStatus", "description" },
                values: new object[] { 1, "Baja" });

            migrationBuilder.InsertData(
                table: "ExecutionStatus",
                columns: new[] { "idExecutionStatus", "description" },
                values: new object[] { 1, "En curso" });

            migrationBuilder.InsertData(
                table: "TicketBody",
                columns: new[] { "idTicketBody", "description", "file", "title" },
                values: new object[,]
                {
                    { 1, "Por favor solicito...", "Ruta archivo", "Solicitud de pagos" },
                    { 2, "Hola equipo! Solicito...", "Ruta archivo", "Solicitud de Factura" }
                });

            migrationBuilder.InsertData(
                table: "TicketCategory",
                columns: new[] { "idCategory", "dateCreate", "description", "name", "reqApproval" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Baja", "name Category", false });

            migrationBuilder.InsertData(
                table: "TicketPriority",
                columns: new[] { "idPriority", "description" },
                values: new object[] { 1, "Baja" });

            migrationBuilder.InsertData(
                table: "TicketStatus",
                columns: new[] { "idStatus", "description" },
                values: new object[] { 1, "En curso" });

            migrationBuilder.InsertData(
                table: "Ticket",
                columns: new[] { "idTicket", "countApproved", "countDisapproved", "countOpen", "idAprovvaStatus", "idTicketCategory", "idExecutionStatus", "idPriority", "idStatus", "idTicketBody", "idUser", "idUserExecutor", "minApproveReq" },
                values: new object[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "TicketComment",
                columns: new[] { "idComment", "comment", "dateComment", "idTicket", "idUser" },
                values: new object[] { 1, "Comentario", new DateTime(2022, 9, 23, 21, 28, 59, 513, DateTimeKind.Local).AddTicks(332), 0, 1 });

            migrationBuilder.InsertData(
                table: "TicketLog",
                columns: new[] { "idTicketLog", "dateHistory", "idAction", "idTicket", "idUser", "idUserCategory" },
                values: new object[] { 1, new DateTime(2022, 9, 23, 21, 28, 59, 512, DateTimeKind.Local).AddTicks(4094), 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "TicketReceptors",
                columns: new[] { "idTicketReceptors", "idTicket", "idUser" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "TicketAction",
                columns: new[] { "idAction", "actionDescription" },
                values: new object[] { 1, "descripcion de la accion" });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_idAprovvaStatus",
                table: "Ticket",
                column: "idAprovvaStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_idExecutionStatus",
                table: "Ticket",
                column: "idExecutionStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_idPriority",
                table: "Ticket",
                column: "idPriority");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_idStatus",
                table: "Ticket",
                column: "idStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_idTicketBody",
                table: "Ticket",
                column: "idTicketBody",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_idTicketCategory",
                table: "Ticket",
                column: "idTicketCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketAction");

            migrationBuilder.DropTable(
                name: "TicketComment");

            migrationBuilder.DropTable(
                name: "TicketReceptors");

            migrationBuilder.DropTable(
                name: "TicketLog");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "ApprovalStatus");

            migrationBuilder.DropTable(
                name: "ExecutionStatus");

            migrationBuilder.DropTable(
                name: "TicketBody");

            migrationBuilder.DropTable(
                name: "TicketCategory");

            migrationBuilder.DropTable(
                name: "TicketPriority");

            migrationBuilder.DropTable(
                name: "TicketStatus");
        }
    }
}
