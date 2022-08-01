using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace JuegoRPG
{
    public class Root
    {
        [JsonPropertyName("name")]
        public string? Nombre { get; set; }

        [JsonPropertyName("alpha3Code")]
        public string? Fifa { get; set; }

        //[JsonPropertyName("independent")]
        //public bool? Indep { get; set; }

        public static implicit operator string(Root v)
        {
            throw new NotImplementedException();
        }
    }
}
