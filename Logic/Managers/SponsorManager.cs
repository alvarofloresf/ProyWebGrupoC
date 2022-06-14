using BackingServices.Services;
using DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Managers
{
    public class SponsorManager
    {
        private UnitOfWork _uow;
        private RestaurantService _restaurantService;

        public SponsorManager(UnitOfWork uow, RestaurantService restaurantService)
        {
            _uow = uow;
            _restaurantService = restaurantService;
        }
        public Logic.Models.Restaurant GetOneSponsor()
        {
            BackingServices.Models.Restaurant restaurantFromService = _restaurantService.GetRestaurantServiceAsync().Result;

            return new Logic.Models.Restaurant()
            {
                Id = restaurantFromService.Id,
                Name = restaurantFromService.Name,
                Description = restaurantFromService.Description,
                PhoneNumber = restaurantFromService.PhoneNumber
            };
        }
        public List<Logic.Models.Sponsor> GetSponsors()
        {
            List<DataBase.Models.Sponsor> sponsorsFromDB = _uow.SponsorRepository.GetAllSponsors().Result;
            List<Logic.Models.Sponsor> mappedSponsors = new List<Logic.Models.Sponsor>();

            foreach (DataBase.Models.Sponsor sponsor in sponsorsFromDB)
            {
                mappedSponsors.Add(new Logic.Models.Sponsor()
                {
                    Id = sponsor.Id,
                    Name = sponsor.Name,
                    Description = sponsor.Description,
                    PhoneNumber = sponsor.PhoneNumber
                }); ;
            }

            return mappedSponsors;
        }
        public Logic.Models.Sponsor CreateSponsor(Logic.Models.Sponsor sponsor)
        {
            DataBase.Models.Sponsor sponsorToCreate = new DataBase.Models.Sponsor()
            {
                Id = new Guid(),
                Name = sponsor.Name,
                Description = sponsor.Description,
                PhoneNumber = sponsor.PhoneNumber
            };
            _uow.SponsorRepository.CreateSponsor(sponsorToCreate);
            _uow.Save();

            return new Logic.Models.Sponsor()
            {
                Id = sponsorToCreate.Id,
                Name = sponsorToCreate.Name,
                Description = sponsorToCreate.Description,
                PhoneNumber = sponsorToCreate.PhoneNumber
            };
        }
        public Logic.Models.Sponsor UpdateSponsor(Logic.Models.Sponsor sponsor)
        {
            DataBase.Models.Sponsor sponsorToUpdate = _uow.SponsorRepository.GetSponsorById(sponsor.Id);

            sponsorToUpdate.Name = sponsor.Name;
            sponsorToUpdate.Description = sponsor.Description;
            sponsorToUpdate.PhoneNumber = sponsor.PhoneNumber;

            _uow.SponsorRepository.UpdateSponsor(sponsorToUpdate);
            _uow.Save();

            return new Logic.Models.Sponsor()
            {
                Id = sponsorToUpdate.Id,
                Name = sponsorToUpdate.Name,
                Description = sponsorToUpdate.Description,
                PhoneNumber = sponsorToUpdate.PhoneNumber
            };
        }

        public Logic.Models.Sponsor DeleteSponsor(Guid sponsorId)
        {
            DataBase.Models.Sponsor sponsorFound = _uow.SponsorRepository.GetSponsorById(sponsorId);

            _uow.SponsorRepository.DeleteSponsor(sponsorFound);
            _uow.Save();

            return new Logic.Models.Sponsor() 
            {
                Id = sponsorFound.Id,
                Name = sponsorFound.Name,
                Description = sponsorFound.Description,
                PhoneNumber = sponsorFound.PhoneNumber
            };
        }
    }
}
