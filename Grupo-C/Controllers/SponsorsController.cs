using Logic.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo_C.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SponsorsController : ControllerBase
    {
        private SponsorManager _sponsorManager;
        public SponsorsController(SponsorManager sponsorManager)
        {
            _sponsorManager = sponsorManager;
        }

        [HttpGet]
        public IActionResult GetSponsors()
        {
            return Ok(_sponsorManager.GetSponsors());
        }

        [HttpGet]
        [Route("id-sponsor")]
        public IActionResult GetOneSponsor()
        {
            return Ok(_sponsorManager.GetOneSponsor());
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] Logic.Models.Sponsor sponsor)
        {
            return Ok(_sponsorManager.CreateSponsor(sponsor));
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] Logic.Models.Sponsor sponsor)
        {
            return Ok(_sponsorManager.UpdateSponsor(sponsor));
        }

        [HttpDelete]
        [Route("{sponsorId}")]
        public IActionResult DeleteSponsor(Guid sponsorId)
        {
            return Ok(_sponsorManager.DeleteSponsor(sponsorId));
        }
    }
}
