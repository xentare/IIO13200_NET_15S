using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtävä7
{
    public class Train
    {
        [JsonProperty("trainNumber")]
        public string Number { get; set; }
        [JsonProperty("departureDate")]
        public string Departure_Date { get; set; }
        [JsonProperty("trainType")]
        public string Type { get; set; }
        public bool cancelled { get; set; }
        //public string 
    }
}
