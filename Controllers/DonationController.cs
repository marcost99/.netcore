using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using donations.Data;
using donations.Models;

namespace donations.Controllers
{
    [ApiController]
    [Route("v1/donations")]
    public class DonationController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Donation>>> Get([FromServices] DataContext context)
        {
            var donations = await context.Donations.ToListAsync();
            return donations;
        }

        // [HttpGet]
        // [Route("{id:int}")]
        // public async Task<ActionResult<Donation>> GetById([FromServices] DataContext context, int id)
        // {
        //     var d = await context.Donations.Include(x => x.Donation).FirstOrDefaultAsync(x => x.Id == id);
        //     return (Donation) d;
        // }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Donation>> Post(
            [FromServices] DataContext context,
            [FromBody]Donation model)
        {
            if(ModelState.IsValid)
            {
                context.Donations.Add(model);
                await context.SaveChangesAsync();
                return (Donation) model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}