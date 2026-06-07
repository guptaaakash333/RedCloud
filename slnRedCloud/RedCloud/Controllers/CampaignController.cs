using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RedCloud.Custom_Action_Filter;
using RedCloud.Interfaces;
using RedCloud.Services;
using RedCloud.ViewModel;
using static RedCloud.Custom_Action_Filter.NoCacheAttribute;

namespace RedCloud.Controllers
{
    [NoCache]
    [AdminAuthorizationFilter]
    public class CampaignController : Controller
    {
        private readonly ICampaignService _campaignService;
        private readonly IOrganizationUserService _organizationUserService ;
        private readonly IResellerUserService _ResellerUserService;

        private readonly ILogger<CampaignController> _logger;

        public CampaignController(ICampaignService campaignService, ILogger<CampaignController> logger, IOrganizationUserService organizationUserService, IResellerUserService resellerUserService)
        {
            _campaignService = campaignService;
            _logger = logger;
            _organizationUserService = organizationUserService;
            _ResellerUserService = resellerUserService;
            
        }

        public async Task<IActionResult> Index()
        {
            var organizationUserList = await _organizationUserService.GetAllOrganizationUser();
            ViewBag.OrganizationUserList = new SelectList(organizationUserList, "OrganizationUserId", "OrganizationUserFirstName") ;
            var resellerUserListr  = await _ResellerUserService.GetAllResellerUser();
            ViewBag.ResellerUserList = new SelectList(resellerUserListr, "ResellerUserId", "FirstName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCampaign(CampaignVM model)
        {

            var userId = HttpContext.Session.GetInt32("UserId");
            // _logger.LogInformation("CreateCampaign Action initiated");
            model.userID = userId;
            var response = await _campaignService.CreateCampaign(model);

            //_logger.LogInformation("CreateCampaign Action completed");
            return RedirectToAction("CampaignViewDetail","Campaigndetail");

        }


        public async Task<IActionResult> ViewCampaignById(int id) 
        {

            //_logger.LogInformation($"Fetching ViewCampaignById with ID: {id}");
            var response = await _campaignService.GetCampaign(id);
            if (response == null)
    {
                //_logger.LogWarning($"ViewCampaignById with ID: {id} not found");
                return NotFound();
            }
            return View(response);
        } 
        
        
        

        
    }
}
