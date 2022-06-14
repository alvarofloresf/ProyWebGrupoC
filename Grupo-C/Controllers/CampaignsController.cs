using Logic.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
using Microsoft.Extensions.Logging;
>>>>>>> DouglasMain

namespace Grupo_C.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        private CampaignManager _campaignManager;
<<<<<<< HEAD
        public CampaignsController(CampaignManager campaignManager)
=======
        private readonly ILogger<CampaignsController> logger;
        public CampaignsController(CampaignManager campaignManager, ILogger<CampaignsController> logger)
>>>>>>> DouglasMain
        {
            _campaignManager = campaignManager;
        }

        [HttpGet]
        public IActionResult GetCampaigns()
        {
<<<<<<< HEAD
            return Ok(_campaignManager.GetCampaigns());
        }
        [HttpGet]
        [Route("is/Active")]
        public IActionResult GetActiveCampaign()
        {
            return Ok(_campaignManager.GetActiveCampaign());
        }
=======
            logger.LogInformation("Se esta obteniendo una campania");
            return Ok(_campaignManager.GetCampaigns());
        }
>>>>>>> DouglasMain

        [HttpPost]
        public IActionResult CreateCampaign([FromBody] Logic.Models.Campaign campaign)
        {
<<<<<<< HEAD
=======
            logger.LogInformation("Se esta creando una campania");
>>>>>>> DouglasMain
            return Ok(_campaignManager.CreateCampaign(campaign));
        }

        [HttpPut]
        public IActionResult UpdateCampaign([FromBody] Logic.Models.Campaign campaign)
        {
<<<<<<< HEAD
=======
            logger.LogWarning("Se esta actualizando una campania");
>>>>>>> DouglasMain
            return Ok(_campaignManager.UpdateCampaign(campaign));
        }

        [HttpDelete]
        [Route("{campaignId}")]
        public IActionResult DeleteSponsor(Guid campaignId)
        {
            return Ok(_campaignManager.DeleteCampaign(campaignId));
        }

        [HttpPut]
<<<<<<< HEAD
        [Route("/enableOrDisableCampaign/{campaignId}")]
        public IActionResult EnableCampaig(Guid campaignId)
        {
            return Ok(_campaignManager.EnableDisableCampaign(campaignId));
=======
        [Route("/enableOrDisableCampaign")]
        public IActionResult EnableCampaig([FromBody] Logic.Models.Campaign campaign)
        {
            return Ok(_campaignManager.EnableDisableCampaign(campaign));
>>>>>>> DouglasMain
        }
    }
}
