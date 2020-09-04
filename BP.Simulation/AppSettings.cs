namespace BP.Simulation
{
    public class AppSettings
    {
        public NamesLists NamesLists { get; set; }
    }

    public class NamesLists
    {
        public string[] FirstNamesMale { get; set; }

        public string[] FirstNamesFemale { get; set; }

        public string[] SurnamesMale { get; set; }

        public string[] SurnamesFemale { get; set; }

        public string[] VehicleTypes { get; set; }
    }
}
