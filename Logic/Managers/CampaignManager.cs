using DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Managers
{
    public class CampaignManager
    {
        private UnitOfWork _uow;
        public CampaignManager(UnitOfWork uow)
        {
            _uow = uow;
        }
        public List<Logic.Models.Campaign> GetCampaigns()
        {
            List<DataBase.Models.Campaign> campaignsFromDB = _uow.CampaignRepository.GetAllCampains().Result;
            List<Logic.Models.Campaign> mappedCampaigns = new List<Logic.Models.Campaign>();

            foreach (DataBase.Models.Campaign campaign in campaignsFromDB)
            {
                mappedCampaigns.Add(new Logic.Models.Campaign()
                {
                    Id = campaign.Id,
                    NameCampaign = campaign.NameCampaign,
                    TypeCampaign = campaign.TypeCampaign,
                    DescriptionCampaign = campaign.DescriptionCampaign,
                    CustomerSponsor = campaign.CustomerSponsor,
                    Enable = campaign.Enable
                }); ;
            }
            return mappedCampaigns;
        }
<<<<<<< HEAD
        public List<Logic.Models.Campaign> GetActiveCampaign()
        {
            List<DataBase.Models.Campaign> campaignsFromDB = _uow.CampaignRepository.GetAllCampains().Result;
            List<Logic.Models.Campaign> activeCampaign = new List<Logic.Models.Campaign>();
            
            foreach (DataBase.Models.Campaign campaign in campaignsFromDB)
            {
                if (campaign.Enable == 1)
                {
                    activeCampaign.Add(new Logic.Models.Campaign()
                    {
                        Id = campaign.Id,
                        NameCampaign = campaign.NameCampaign,
                        TypeCampaign = campaign.TypeCampaign,
                        DescriptionCampaign = campaign.DescriptionCampaign,
                        CustomerSponsor = campaign.CustomerSponsor,
                        Enable = campaign.Enable
                    });
                }
            }
            return activeCampaign;
        }
=======

>>>>>>> DouglasMain
        public Logic.Models.Campaign CreateCampaign(Logic.Models.Campaign campaign)
        {
            DataBase.Models.Campaign campaignToCreate = new DataBase.Models.Campaign()
            {
                Id = new Guid(),
                NameCampaign = campaign.NameCampaign,
                TypeCampaign = campaign.TypeCampaign,
                DescriptionCampaign = campaign.DescriptionCampaign,
                CustomerSponsor = campaign.CustomerSponsor,
<<<<<<< HEAD
                //Enable = 0
            };
            if (campaignToCreate.TypeCampaign == "Navidad" || campaignToCreate.TypeCampaign == "navidad" || campaignToCreate.TypeCampaign == "NAVIDAD")
            {
                campaignToCreate.TypeCampaign = "XMAS";
                _uow.CampaignRepository.CreateCampaign(campaignToCreate);
                _uow.Save();
            }
            if (campaignToCreate.TypeCampaign == "Verano" || campaignToCreate.TypeCampaign == "verano" || campaignToCreate.TypeCampaign == "VERANO")
            {
                campaignToCreate.TypeCampaign = "SUMMER";
                _uow.CampaignRepository.CreateCampaign(campaignToCreate);
                _uow.Save();
            }
            if (campaignToCreate.TypeCampaign == "Black Friday" || campaignToCreate.TypeCampaign == "BLACK FRIDAY")
            {
                campaignToCreate.TypeCampaign = "BRIDAY";
                _uow.CampaignRepository.CreateCampaign(campaignToCreate);
                _uow.Save();
            }
=======
                Enable = 0
            };
            _uow.CampaignRepository.CreateCampaign(campaignToCreate);
            _uow.Save();
>>>>>>> DouglasMain

            return new Logic.Models.Campaign()
            {
                Id = new Guid(),
                NameCampaign = campaignToCreate.NameCampaign,
                TypeCampaign = campaignToCreate.TypeCampaign,
                DescriptionCampaign = campaignToCreate.DescriptionCampaign,
                CustomerSponsor = campaignToCreate.CustomerSponsor,
<<<<<<< HEAD
                Enable = 0
=======
                //Enable = 0
>>>>>>> DouglasMain
            };
        }
        public Logic.Models.Campaign UpdateCampaign(Logic.Models.Campaign campaign)
        {
            DataBase.Models.Campaign campaignToUpdate = _uow.CampaignRepository.GetCampaignById(campaign.Id);

            campaignToUpdate.NameCampaign = campaign.NameCampaign;
            campaignToUpdate.TypeCampaign = campaign.TypeCampaign;
            campaignToUpdate.DescriptionCampaign = campaign.DescriptionCampaign;
            campaignToUpdate.CustomerSponsor = campaign.CustomerSponsor;

            _uow.CampaignRepository.UpdateCampaign(campaignToUpdate);
            _uow.Save();

            return new Logic.Models.Campaign()
            {
                Id = campaignToUpdate.Id,
                NameCampaign = campaignToUpdate.NameCampaign,
                TypeCampaign = campaignToUpdate.TypeCampaign,
                DescriptionCampaign = campaignToUpdate.DescriptionCampaign,
                CustomerSponsor = campaignToUpdate.CustomerSponsor,
            };
        }
<<<<<<< HEAD
        public Logic.Models.Campaign EnableDisableCampaign(Guid campaignId)
        {
            DataBase.Models.Campaign campaignToUpdate = _uow.CampaignRepository.GetCampaignById(campaignId);

            if(campaignToUpdate.Enable == 0)
            {
                campaignToUpdate.Enable = 1;
                _uow.CampaignRepository.UpdateCampaign(campaignToUpdate);
                _uow.Save();
=======
        public Logic.Models.Campaign EnableDisableCampaign(Logic.Models.Campaign campaign)
        {
            DataBase.Models.Campaign campaignToUpdate = _uow.CampaignRepository.GetCampaignById(campaign.Id);

            if(campaign.Enable == 0)
            {
                campaignToUpdate.Enable = 1;
>>>>>>> DouglasMain
            }
            else
            {
                campaignToUpdate.Enable = 0;
<<<<<<< HEAD
                _uow.CampaignRepository.UpdateCampaign(campaignToUpdate);
                _uow.Save();
            }
            
=======
            }
            
            _uow.CampaignRepository.UpdateCampaign(campaignToUpdate);
            _uow.Save();

>>>>>>> DouglasMain
            return new Logic.Models.Campaign()
            {
                Id = campaignToUpdate.Id,
                Enable = campaignToUpdate.Enable
            };
        }
        public Logic.Models.Campaign DeleteCampaign(Guid campaignId)
        {
            DataBase.Models.Campaign campaignFound = _uow.CampaignRepository.GetCampaignById(campaignId);

            _uow.CampaignRepository.DeleteCampaign(campaignFound);
            _uow.Save();

            return new Logic.Models.Campaign()
            {
                Id = campaignFound.Id,
                NameCampaign = campaignFound.NameCampaign,
                TypeCampaign = campaignFound.TypeCampaign,
                DescriptionCampaign = campaignFound.DescriptionCampaign,
                CustomerSponsor = campaignFound.CustomerSponsor,
                Enable = campaignFound.Enable
            };
        }
    }
}
