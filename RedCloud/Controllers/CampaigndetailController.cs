using Microsoft.AspNetCore.Mvc;
using RedCloud.Custom_Action_Filter;
using RedCloud.Interfaces;
using RedCloud.Services;
using RedCloud.ViewModel;
using static RedCloud.Custom_Action_Filter.NoCacheAttribute;

namespace RedCloud.Controllers
{
    [NoCache]
    [AdminAuthorizationFilter]
    public class CampaigndetailController : Controller
    {



        private readonly ICampaignService _CampaignService;
       // private readonly IAdminResellerUser _reSellerAdminService;
        private readonly ILogger<CampaigndetailController> _logger;
      //  private readonly IDropDownService<CountryVM> _dropDownService;
      //  private readonly IStateService<StateVM> _stateService;
      //  private readonly ICityService<CityVM> _cityService;


        public CampaigndetailController(ICampaignService CampaignService , ILogger<CampaigndetailController> logger)
        {
            _CampaignService = CampaignService;
          
            //_reSellerAdminService = reSellerAdminService;
            _logger = logger;
          //  _dropDownService = dropDownService;
            //_stateService = stateService;
           // _cityService = cityService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CampaignViewDetail() 
        {
            //_logger.LogInformation("ViewResellerAdmin Action initiated");
            var response = await _CampaignService.GetallCampaign();//called iService methodid
            //_logger.LogInformation("ViewResellerAdmin Action completed");
            return View(response);
        }



        [HttpGet]
        public async Task<IActionResult> SoftDeleteCampaign(int id)
        {
            try
            {
                await _CampaignService.SoftDeleteCampaign(id)
  ;
                return Ok($"ResellerAdmin with ID {id} has been soft deleted.");
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred while soft deleting ResellerAdmin with ID {id}: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
