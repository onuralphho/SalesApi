using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesProject.Context;
using SalesProject.Entities;
using SalesProject.Models.Campaign.DTO;
using SalesProject.Models.Product.Response;

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
            var newCampaing = new Campaign
            {
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

        [HttpPut]
        [Route("ResetCampaign/{sku}")]
        public async Task<ProductGetAllResponse> ResetCampaign(string sku)
        {
            var product = await _context.Product
                 .Include(p => p.ActiveCampaign)
                 .SingleOrDefaultAsync(x => x.Sku == sku);

            product.ActiveCampaignId = null;

            await _context.SaveChangesAsync();

            return _mapper.Map<ProductGetAllResponse>(product);



        }
        [HttpPut("ResetCampaign")]
        public async Task<ProductGetAllResponse> ResetCampaignWithOutDetail(string sku)
        {
            var product = await _context.Product
                 .Include(p => p.ActiveCampaign)
                 .SingleOrDefaultAsync(x => x.Sku == sku);
            if (product != null)
            {
                product.ActiveCampaignId = null;

                await _context.SaveChangesAsync();
            }


            return _mapper.Map<ProductGetAllResponse>(product);



        }
    }
}
