using BP.StoredProcedures.Definitions;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BP.Migrations
{
    public partial class AddStoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            CustomerSPDefinitions.CreateDefinitions();
            foreach (var definition in CustomerSPDefinitions.Definitions)
                migrationBuilder.Sql(definition.Value);
            DriverSPDefinitions.CreateDefinitions();
            foreach (var definition in DriverSPDefinitions.Definitions)
                migrationBuilder.Sql(definition.Value);
            VehicleSPDefinitions.CreateDefinitions();
            foreach (var definition in VehicleSPDefinitions.Definitions)
                migrationBuilder.Sql(definition.Value);
            OrderSPDefinitions.CreateDefinitions();
            foreach (var definition in OrderSPDefinitions.Definitions)
                migrationBuilder.Sql(definition.Value);
            VehicleRentSPDefinitions.CreateDefinitions();
            foreach (var definition in VehicleRentSPDefinitions.Definitions)
                migrationBuilder.Sql(definition.Value);
            UserIdentitySPDefinitions.CreateDefinitions();
            foreach (var definition in UserIdentitySPDefinitions.Definitions)
                migrationBuilder.Sql(definition.Value);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
