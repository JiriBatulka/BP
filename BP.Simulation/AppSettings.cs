using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BP
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
