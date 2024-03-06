using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class InitailCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    province_id = table.Column<int>(type: "int", nullable: false),
                    province_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    province_type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.province_id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    roleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.roleID);
                });

            migrationBuilder.CreateTable(
                name: "RoomAmenities",
                columns: table => new
                {
                    amenitiesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amenitiesName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amenitiesPrice = table.Column<double>(type: "float", nullable: false),
                    amenitiesDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenities", x => x.amenitiesID);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    district_id = table.Column<int>(type: "int", nullable: false),
                    district_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    district_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    province_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.district_id);
                    table.ForeignKey(
                        name: "FK_Districts_Provinces_province_id",
                        column: x => x.province_id,
                        principalTable: "Provinces",
                        principalColumn: "province_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    ward_id = table.Column<int>(type: "int", nullable: false),
                    ward_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ward_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    district_id = table.Column<int>(type: "int", nullable: false),
                    lat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.ward_id);
                    table.ForeignKey(
                        name: "FK_Wards_Districts_district_id",
                        column: x => x.district_id,
                        principalTable: "Districts",
                        principalColumn: "district_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roleID = table.Column<int>(type: "int", nullable: false),
                    wardID = table.Column<int>(type: "int", nullable: false),
                    deleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_roleID",
                        column: x => x.roleID,
                        principalTable: "Roles",
                        principalColumn: "roleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Wards_wardID",
                        column: x => x.wardID,
                        principalTable: "Wards",
                        principalColumn: "ward_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    roomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wardID = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    area = table.Column<double>(type: "float", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    publicDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    longitude = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.roomID);
                    table.ForeignKey(
                        name: "FK_Rooms_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID");
                    table.ForeignKey(
                        name: "FK_Rooms_Wards_wardID",
                        column: x => x.wardID,
                        principalTable: "Wards",
                        principalColumn: "ward_id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    imageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roomID = table.Column<int>(type: "int", nullable: false),
                    order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.imageID);
                    table.ForeignKey(
                        name: "FK_Images_Rooms_roomID",
                        column: x => x.roomID,
                        principalTable: "Rooms",
                        principalColumn: "roomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    messageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roomID = table.Column<int>(type: "int", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sendDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.messageID);
                    table.ForeignKey(
                        name: "FK_Messages_Rooms_roomID",
                        column: x => x.roomID,
                        principalTable: "Rooms",
                        principalColumn: "roomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    roomID = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    grade = table.Column<float>(type: "real", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    reviewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => new { x.roomID, x.userID });
                    table.ForeignKey(
                        name: "FK_Reviews_Rooms_roomID",
                        column: x => x.roomID,
                        principalTable: "Rooms",
                        principalColumn: "roomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomAmenitiesMappings",
                columns: table => new
                {
                    roomID = table.Column<int>(type: "int", nullable: false),
                    amenitiesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenitiesMappings", x => new { x.roomID, x.amenitiesID });
                    table.ForeignKey(
                        name: "FK_RoomAmenitiesMappings_RoomAmenities_amenitiesID",
                        column: x => x.amenitiesID,
                        principalTable: "RoomAmenities",
                        principalColumn: "amenitiesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomAmenitiesMappings_Rooms_roomID",
                        column: x => x.roomID,
                        principalTable: "Rooms",
                        principalColumn: "roomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_province_id",
                table: "Districts",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "IX_Images_roomID",
                table: "Images",
                column: "roomID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_roomID",
                table: "Messages",
                column: "roomID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_userID",
                table: "Reviews",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenitiesMappings_amenitiesID",
                table: "RoomAmenitiesMappings",
                column: "amenitiesID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_userID",
                table: "Rooms",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_wardID",
                table: "Rooms",
                column: "wardID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_roleID",
                table: "Users",
                column: "roleID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_wardID",
                table: "Users",
                column: "wardID");

            migrationBuilder.CreateIndex(
                name: "IX_Wards_district_id",
                table: "Wards",
                column: "district_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "RoomAmenitiesMappings");

            migrationBuilder.DropTable(
                name: "RoomAmenities");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Wards");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
