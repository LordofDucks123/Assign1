using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Assign2.Data;
using Microsoft.AspNetCore.Mvc;

namespace Assign_2.Controllers{
    
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
        private IAdult methods;

        public AdultController(IAdult methods)
        {
            this.methods = methods;
        }
        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults([FromQuery] int? adultId)
        {
            try
            {
                IList<Adult> adults = await methods.GetAdultsAsync();
                if(adultId != null)
                {
                    adults = adults.Where(adult => adult.Id == adultId).ToList();
                }
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteAdult([FromRoute] int id)
        {
            try
            {
                await methods.RemoveAdult(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Adult added = await methods.AddAdult(adult);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> UpdateAdult([FromBody] Adult adult)
        {
            try
            {
                Adult updatedAdult = await methods.UpdateAsync(adult);
                return Ok(updatedAdult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
