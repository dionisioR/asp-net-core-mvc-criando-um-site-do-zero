using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LancheMac_SSMS.Migrations
{
    public partial class PopularCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Categoria(CategoriaNome, Descricao) " +
                "values('Normal', 'Lanche feito com os melhores ingredientes')");

            migrationBuilder.Sql("insert into Categoria(CategoriaNome, Descricao) " +
                "values('Natural', 'Lanche feito com ingredientes integrais e naturais')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categoria");
        }
    }
}
