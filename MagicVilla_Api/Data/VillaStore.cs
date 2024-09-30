using MagicVilla_Api.Model.Dto;

namespace MagicVilla_Api.Data
{
    public class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto>
        {
            new VillaDto { Id = 1, Name = "Pool View", Occupancy=50,SqFeet=3000 },

                new VillaDto { Id = 2, Name = "Beach View", Occupancy=40, SqFeet=2000 },
        };
        internal static IEnumerable<VillaDto> villa;
    }
}
