using Logic.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Grupo_C.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        private CampaignManager _campaignManager;
        private readonly ILogger<CampaignsController> logger;
        public CampaignsController(CampaignManager campaignManager, ILogger<CampaignsController> logger)
        {
            _campaignManager = campaignManager;
        }

        [HttpGet]
        public IActionResult GetCampaigns()
        {
            logger.LogInformation("Se esta obteniendo una campania");
            return Ok(_campaignManager.GetCampaigns());
        }

        [HttpPost]
        public IActionResult CreateCampaign([FromBody] Logic.Models.Campaign campaign)
        {
            logger.LogInformation("Se esta creando una campania");
            return Ok(_campaignManager.CreateCampaign(campaign));
        }

        [HttpPut]
        public IActionResult UpdateCampaign([FromBody] Logic.Models.Campaign campaign)
        {
            logger.LogWarning("Se esta actualizando una campania");
            return Ok(_campaignManager.UpdateCampaign(campaign));
        }

        [HttpDelete]
        [Route("{campaignId}")]
        public IActionResult DeleteSponsor(Guid campaignId)
        {
            return Ok(_campaignManager.DeleteCampaign(campaignId));
        }

        [HttpPut]
        [Route("/enableOrDisableCampaign")]
        public IActionResult EnableCampaig([FromBody] Logic.Models.Campaign campaign)
        {
            return Ok(_campaignManager.EnableDisableCampaign(campaign));
        }
    }
}
