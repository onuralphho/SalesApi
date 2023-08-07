using Microsoft.EntityFrameworkCore;
using SalesProject.Context;
using SalesProject.Core.Interfaces.RepositoryInterfaces;
using SalesProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Domain.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly SalesDbContext _context;

        public CampaignRepository(SalesDbContext context)
        {
            _context = context;
        }

        public async Task<List<Campaign>> GetCampaignsAsync()
        {
            return await _context.Campaign.ToListAsync();
        }

        public async Task<Campaign> CreateCampignAsync(Campaign campaign)
        {
            _context.Campaign.Add(campaign);

            await _context.SaveChangesAsync();

            return campaign;
        }

    }
}
