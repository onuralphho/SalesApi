using SalesProject.Models.Campaign.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Core.Interfaces.ServiceInterfaces
{
    public interface ICampaignService
    {
        Task<List<CampaignDto>> GetCampaigns();
        Task<CampaignDto> CreateCampaign(CampaignDto campaign);
    }
}
