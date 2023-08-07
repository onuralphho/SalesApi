using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesProject.Context;
using SalesProject.Core.Interfaces.ServiceInterfaces;
using SalesProject.Entities;
using SalesProject.Exceptions;
using SalesProject.Models.Campaign.DTO;
using SalesProject.Models.Product.Response;

namespace SalesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _campaignService;

        public CampaignController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpGet]
        public async Task<List<CampaignDto>> GetCampaigns()
        {
            var response = await _campaignService.GetCampaigns();
            if (response != null)
            {
                return response;
            }
            else
            {
                throw new BadRequestException("Something went wrong when getting campaign list");
            }
        }

        [HttpPost("CreateCampaign")]
        public async Task<CampaignDto> CreateCampaign(CampaignDto campaign)
        {
            var response = await _campaignService.CreateCampaign(campaign);
            if (response != null)
            {
                return response;
            }
            else
            {
                throw new BadRequestException("Something went wrong when adding new campaign");
            }

        }


    }
}
