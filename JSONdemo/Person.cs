using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONdemo
{
    public class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }

    }
    public class Politic : Person
    {
        public string Party { get; set; }
        [JsonProperty("position")]
        public string Virka { get; set; }
    }
}
