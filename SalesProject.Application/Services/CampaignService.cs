using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesProject.Core.Interfaces.RepositoryInterfaces;
using SalesProject.Core.Interfaces.ServiceInterfaces;
using SalesProject.Entities;
using SalesProject.Models.Campaign.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Application.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly IMapper _mapper;
        private readonly ICampaignRepository _campaignRepository;

        public CampaignService(IMapper mapper, ICampaignRepository campaignRepository)
        {
            _mapper = mapper;
            _campaignRepository = campaignRepository;
        }

        public async Task<List<CampaignDto>> GetCampaigns()
        {
            var campaigns = await _campaignRepository.GetCampaignsAsync();
            return _mapper.Map<List<CampaignDto>>(campaigns);
        }

        public async Task<CampaignDto> CreateCampaign(CampaignDto campaign)
        {
            var newCampaing = new Campaign
            {
                Title = campaign.Title,
                Description = campaign.Description,
                DiscountValue = campaign.DiscountValue,
                StartDate = campaign.StartDate,
                EndDate = campaign.EndDate,
            };

            await _campaignRepository.CreateCampignAsync(newCampaing);

            return _mapper.Map<CampaignDto>(newCampaing);
        }

    }
}
