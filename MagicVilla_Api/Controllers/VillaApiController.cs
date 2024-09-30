using MagicVilla_Api.Data;
using MagicVilla_Api.Model;
using MagicVilla_Api.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_Api.Controllers
{
    // we can also write [Route("api/[controller]")] but it is a bad practice.
    [Route("api/VillaApi")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        [HttpGet]
        //with actionResult we can return anything
        public ActionResult <IEnumerable<VillaDto>> GetVillas()
        {
            //getting all the villas
            return VillaStore.villaList;
        }

        [HttpGet("id:int")]
        public VillaDto GetVilla(int id) => VillaStore.villaList.FirstOrDefault(u => u.Id == id);
    }
}
