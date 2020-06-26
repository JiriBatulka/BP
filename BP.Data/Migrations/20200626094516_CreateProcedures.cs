using BP.StoredProcedures.Definitions;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BP.Migrations
{
    public partial class CreateProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            foreach (var definition in CustomerSPDefinitions.Definitions)
                migrationBuilder.Sql(definition.Value);

            foreach (var definition in DriverSPDefinitions.Definitions)
                migrationBuilder.Sql(definition.Value);

            foreach (var definition in VehicleSPDefinitions.Definitions)
                migrationBuilder.Sql(definition.Value);

            foreach (var definition in OrderSPDefinitions.Definitions)
                migrationBuilder.Sql(definition.Value);

            foreach (var definition in VehicleRentSPDefinitions.Definitions)
                migrationBuilder.Sql(definition.Value);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
