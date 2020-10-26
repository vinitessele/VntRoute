using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VntRoute
{
    public class DtoRota
    {
        public int id { get; set; }
        [JsonProperty("html_instructions")]
        public string html_instructions { get; set; }
        [JsonProperty("duration")]
        public string duration { get; set; }
        [JsonProperty("distance")]
        public string distance { get; set; }
        [JsonProperty("start_latitude")]
        public string start_latitude { get; set; }
        [JsonProperty("start_longitude")]
        public string start_longitude { get; set; }
        [JsonProperty("end_latitude")]
        public string end_latitude { get; set; }
        [JsonProperty("end_longitude")]
        public string end_longitude { get; set; }
        [JsonProperty("start_address")]
        public string start_address { get; set; }
        [JsonProperty("end_address")]
        public string end_address { get; set; }
        [JsonProperty("waypoint_order")]
        public int? waypoint_order { get; set; }
    }
}
