using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using powerplant_coding_challenge_implementation.Enum;

namespace powerplant_coding_challenge_implementation.Models
{
    public class PowerPlant
    {
        public string Name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PowerPlantType Type { get; set; }
        public float Efficiency { get; set; }
        public int PMin { get; set; }
        public int PMax { get; set; }
        public int PActual { get; set; }

        public PowerPlant(string name, PowerPlantType type, float efficiency, int pMin, int pMax, int pActual)
        {
            Name=name;
            Type=type;
            Efficiency=efficiency;
            PMin=pMin;
            PMax=pMax;
            PActual=pActual;
        }
    }
}