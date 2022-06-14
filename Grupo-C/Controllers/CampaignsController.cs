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
    public class CampaignsController : ControllerBase
    {
        private CampaignManager _campaignManager;
        public CampaignsController(CampaignManager campaignManager)
        {
            _campaignManager = campaignManager;
        }

        [HttpGet]
        public IActionResult GetCampaigns()
        {
            return Ok(_campaignManager.GetCampaigns());
        }
        [HttpGet]
        [Route("is/Active")]
        public IActionResult GetActiveCampaign()
        {
            return Ok(_campaignManager.GetActiveCampaign());
        }

        [HttpPost]
        public IActionResult CreateCampaign([FromBody] Logic.Models.Campaign campaign)
        {
            return Ok(_campaignManager.CreateCampaign(campaign));
        }

        [HttpPut]
        public IActionResult UpdateCampaign([FromBody] Logic.Models.Campaign campaign)
        {
            return Ok(_campaignManager.UpdateCampaign(campaign));
        }

        [HttpDelete]
        [Route("{campaignId}")]
        public IActionResult DeleteSponsor(Guid campaignId)
        {
            return Ok(_campaignManager.DeleteCampaign(campaignId));
        }

        [HttpPut]
        [Route("/enableOrDisableCampaign/{campaignId}")]
        public IActionResult EnableCampaig(Guid campaignId)
        {
            return Ok(_campaignManager.EnableDisableCampaign(campaignId));
        }
    }
}
