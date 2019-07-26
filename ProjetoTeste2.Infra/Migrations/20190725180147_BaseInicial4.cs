using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoTeste2.Infra.Migrations
{
    public partial class BaseInicial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EnderecoTipo");

            migrationBuilder.DropColumn(
                name: "RecordTimeStamp",
                table: "EnderecoTipo");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "RecordTimeStamp",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ClienteContato");

            migrationBuilder.DropColumn(
                name: "RecordTimeStamp",
                table: "ClienteContato");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "RecordTimeStamp",
                table: "Cliente");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bd14693-d749-4586-a748-b2c2e67e44e9",
                column: "ConcurrencyStamp",
                value: "4ec517e1-c152-4aed-aad7-b1763381bed1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "35505200-6e1a-4cd8-a9ac-0021bffe60fa", "AQAAAAEAACcQAAAAEAkOQ5VmNTEP9VorqY29LFOLBwEG3gNuZT1NiEZkk9o/g2Lia9oBkKfE7RNZ6vWNVA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EnderecoTipo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "RecordTimeStamp",
                table: "EnderecoTipo",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Endereco",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "RecordTimeStamp",
                table: "Endereco",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ClienteContato",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "RecordTimeStamp",
                table: "ClienteContato",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cliente",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "RecordTimeStamp",
                table: "Cliente",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bd14693-d749-4586-a748-b2c2e67e44e9",
                column: "ConcurrencyStamp",
                value: "6e1c3692-bd79-4248-8465-d0176e004502");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4995f09b-a368-4feb-9708-224e6b3d4dd0", "AQAAAAEAACcQAAAAEIqLKny3YRY4+ylCB3j4TGzKnwYT3AWQgf8dTtG2z+W6qtDiuYAtBOZxnPUFQ6Z3tg==" });
        }
    }
}
