using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManegmantWpfApp.Migrations
{
    public partial class add_reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(maxLength: 50, nullable: false),
                    last_name = table.Column<string>(maxLength: 50, nullable: false),
                    birth_day = table.Column<string>(maxLength: 50, nullable: false),
                    gender = table.Column<string>(maxLength: 50, nullable: false),
                    phone_number = table.Column<string>(maxLength: 50, nullable: false),
                    email_address = table.Column<string>(nullable: false),
                    number_guest = table.Column<int>(nullable: false),
                    street_address = table.Column<string>(nullable: false),
                    apt_suite = table.Column<string>(maxLength: 50, nullable: false),
                    city = table.Column<string>(nullable: false),
                    state = table.Column<string>(maxLength: 50, nullable: false),
                    zip_code = table.Column<string>(maxLength: 10, nullable: false),
                    room_type = table.Column<string>(maxLength: 10, nullable: false),
                    room_floor = table.Column<string>(maxLength: 10, nullable: false),
                    room_number = table.Column<string>(maxLength: 10, nullable: false),
                    total_bill = table.Column<float>(nullable: false),
                    payment_type = table.Column<string>(maxLength: 10, nullable: false),
                    card_type = table.Column<string>(maxLength: 10, nullable: false),
                    card_number = table.Column<string>(maxLength: 50, nullable: false),
                    card_exp = table.Column<string>(maxLength: 50, nullable: false),
                    card_cvc = table.Column<string>(maxLength: 10, nullable: false),
                    arrival_time = table.Column<DateTime>(nullable: false),
                    leaving_time = table.Column<DateTime>(nullable: false),
                    check_in = table.Column<bool>(nullable: false),
                    break_fast = table.Column<int>(nullable: false),
                    lunch = table.Column<int>(nullable: false),
                    dinner = table.Column<int>(nullable: false),
                    cleaning = table.Column<bool>(nullable: false),
                    towel = table.Column<bool>(nullable: false),
                    s_surprise = table.Column<bool>(nullable: false),
                    supply_status = table.Column<bool>(nullable: false),
                    food_bill = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservations");
        }
    }
}
