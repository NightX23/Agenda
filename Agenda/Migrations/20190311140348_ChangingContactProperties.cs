using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Agenda.Migrations
{
    public partial class ChangingContactProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Contacts",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Contacts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "Contacts",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Contacts",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Contacts",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Contacts",
                newName: "Direccion");
        }
    }
}
