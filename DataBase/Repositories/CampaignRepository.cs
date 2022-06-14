using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public class CampaignRepository
    {
        private PracticeDbContext _context;
        public CampaignRepository(PracticeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Campaign>> GetAllCampains()
        {
            return await _context.Set<Campaign>().ToListAsync();
        }

        public Campaign CreateCampaign(Campaign campaign)
        {
            _context.Set<Campaign>().Add(campaign);
            return campaign;
        }

        public Campaign GetCampaignById(Guid id)
        {
            return _context.Set<Campaign>().Find(id);
        }

        public Campaign UpdateCampaign(Campaign campaign)
        {
            _context.Entry(campaign).State = EntityState.Modified;
            return campaign;
        }

        public Campaign DeleteCampaign(Campaign campaign)
        {
            _context.Set<Campaign>().Remove(campaign);
            return campaign;
        }
    }
}
