using System.Runtime.Serialization;

namespace powerplant_coding_challenge_implementation.Enum
{
	public enum PowerPlantType
	{
		[EnumMember(Value = "windturbine")]
		WINDTURBINE,
		[EnumMember(Value = "turbojet")]
		TURBOJET,
		[EnumMember(Value = "gasfired")]
		GASFIRED
	}
}
