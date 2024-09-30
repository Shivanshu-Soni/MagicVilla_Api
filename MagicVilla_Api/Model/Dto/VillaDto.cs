using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Api.Model.Dto
{
    public class VillaDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        
        public string? Name { get; set; }
        public DateTime Createdtime { get; set; }
    } 

}
