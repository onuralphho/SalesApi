using SalesProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Core.Interfaces.RepositoryInterfaces
{
    public interface ICampaignRepository
    {
        Task<List<Campaign>> GetCampaignsAsync();
        Task<Campaign> CreateCampignAsync(Campaign campaign);
    }
}
