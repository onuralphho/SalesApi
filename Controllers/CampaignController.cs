using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesProject.Context;
using SalesProject.Entities;
using SalesProject.Models.Campaign.DTO;

namespace SalesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly SalesDbContext _context;
        private readonly IMapper _mapper;

        public CampaignController(IMapper mapper, SalesDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<List<CampaignDto>> GetCampaigns()
        {
            var campaigns = await _context.Campaign.ToListAsync();

            return campaigns.Select(c =>
            {
                return _mapper.Map<CampaignDto>(c);
            }).ToList();
        }

        [HttpPost("CreateCampaign")]
        public async Task<CampaignDto> CreateCampaign(CampaignDto campaign)
        {
            var newCampaing = new Campaign{
                Title = campaign.Title,
                Description = campaign.Description, 
                DiscountValue = campaign.DiscountValue,
                StartDate = campaign.StartDate,
                EndDate = campaign.EndDate,

            };

            _context.Campaign.Add(newCampaing);

            await _context.SaveChangesAsync();

            return _mapper.Map<CampaignDto>(newCampaing);

        }
    }
}
