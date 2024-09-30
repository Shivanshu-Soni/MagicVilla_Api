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
            return Ok( VillaStore.villaList);
        }

        [HttpGet("{id:int}" , Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(300)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(200,Type= typeof(VillaDto))]
        public ActionResult<VillaDto> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();

            }

             var villa =  VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null) {
                return NotFound();
            }
            return Ok(villa );
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> CreateVilla([FromBody]VillaDto villa) {
            //dont use apicontroller and this code willbe hit 
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if(VillaStore.villaList.FirstOrDefault(u=>u.Name.ToLower() == villa.Name.ToLower()) != null){
                ModelState.AddModelError("Custom err", "Villa Already Exist");
                return BadRequest(ModelState);
            }

            if(villa == null)
            {
                return BadRequest(villa);
            }
            if (villa.Id > 0)
            {   
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villa.Id = VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id+1;
            VillaStore.villaList.Add(villa);
            //return Ok(villa);
            return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa);
        }
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
       
        [HttpDelete("{id:int}", Name = "DeleteVilla") ]
        public IActionResult DeleteVilla(int id)
        {
            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (id == 0)
            {
                return BadRequest();
            }
            VillaStore.villaList.Remove(villa);
            //return Ok();
            return NoContent();
        }

        [HttpPut("{id:int}", Name ="UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        //here we will need id of villa to update and content from body to update
        public ActionResult UpdateVilla(int id,[FromBody] VillaDto villa)
        {
            if ( villa == null | id != villa.Id)
            {
                return BadRequest();
            }
            var nvilla = VillaStore.villaList.FirstOrDefault(u=>u.Id == id);
            nvilla.Name = villa.Name;
            nvilla.SqFeet = villa.SqFeet;
            nvilla.Occupancy = villa.Occupancy;

            return NoContent();


        }
    }
}
