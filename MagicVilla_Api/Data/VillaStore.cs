using MagicVilla_Api.Model.Dto;

namespace MagicVilla_Api.Data
{
    public class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto>
        {
            new VillaDto { Id = 1, Name = "Pool View" },

                new VillaDto { Id = 2, Name = "Beach View" },
        };
        internal static IEnumerable<VillaDto> villa;
    }
}
