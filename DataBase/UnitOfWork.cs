using DataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public class UnitOfWork
    {
        private PracticeDbContext _context;
        private SponsorRepository _sponsorRepository;
        //private CampaignRepository _campaignRepository;

        public SponsorRepository SponsorRepository
        {
            get
            {
                return _sponsorRepository;
            }
        }

        /*public CampaignRepository CampaignRepository
        {
            get
            {
                return _campaignRepository;
            }
        }*/

        public UnitOfWork(PracticeDbContext context)
        {
            _context = context;
            _sponsorRepository = new SponsorRepository(_context);
            //_campaignRepository = new CampaignRepository(_context);
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollBackTransaction()
        {
            _context.Database.RollbackTransaction();
        }
        public void Save()
        {
            try
            {
                BeginTransaction();
                _context.SaveChanges();
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                throw;
            }
        }
    }
}
