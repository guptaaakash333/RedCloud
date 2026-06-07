using Microsoft.AspNetCore.Mvc;
using RedCloud.Custom_Action_Filter;
using RedCloud.Interfaces;
using RedCloud.ViewModel;
using static RedCloud.Custom_Action_Filter.NoCacheAttribute;

namespace RedCloud.Controllers
{
    [NoCache]
    [AdminAuthorizationFilter]
    public class ResellerUserController : Controller
    {
        private readonly IResellerUserService _ResellerUserService;
        private readonly IOrganizationAdminService _organizationAdminService;
        private readonly ILogger<ResellerUserController> _logger;



        public ResellerUserController(IResellerUserService ResellerUserService, ILogger<ResellerUserController> logger)
        {
            _ResellerUserService = ResellerUserService;
            _logger = logger;

        }

        // AAKASh

        [HttpGet]
        public async Task<IActionResult> ViewResellerUsers(int Id)
        { 
            TempData["ResellerUserId"] = Id;    //to get id of Reseller Admin
            //_logger.LogInformation("ViewOrganizationAdmin Action initiated");
            var model = (await _ResellerUserService.GetAllResellerUser()).Where(x => x.ResellerAdminUserId == Id).ToList() ;    //method present in service
            //_logger.LogInformation("ViewOrganizationAdmin Action completed");
            return View(model);
        }


        public async Task<IActionResult> ViewResellerUserDetails(int id)
        {

            //_logger.LogInformation($"Fetching ViewOrganizationDetails with ID: {id}");
            var response = await _ResellerUserService.GetResellerUserDetailesById(id)
;
            if (response == null)
            {
                _logger.LogWarning($"ViewOrganizationDetails with ID: {id} not found");
                return NotFound();
            }

            return View(response);
        }



        [HttpPut]
        public async Task<IActionResult> Block(int id)
        {
            try
            {
                var response = await _ResellerUserService.BlockResellerUser(id)
;
                return View(response);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while blocking the OrganizationAdmin." });
            }
        }


        // ---------------------------------------------------------------------------------
        [AdminAuthorizationFilter]
        public async Task<IActionResult> AddResellerUser()
        {
            //ViewBag.ResellerList = (await _reSellerAdminService.GetallResellerAdmin()).Select(r => r.ResellerName).ToList();
            //return View(); 

            var id = (int)TempData["ResellerUserId"];
            var model =new ResellerUserVM { ResellerAdminUserId = id };


           // return View(new ResellerUserVM());

            return View(model);
        }   

        [HttpPost]
        public async Task<IActionResult> AddResellerUser(ResellerUserVM request)
        {
            // _logger.LogInformation("CreateCategory Action initiated");


            var response = await _ResellerUserService.CreateResellerUser(request);
            var Id=request.ResellerAdminUserId;
            //_logger.LogInformation("CreateCategory Action initiated");
            return RedirectToAction("ViewResellerUsers",new { id = Id});


        }

        public async Task<IActionResult> UpdateResellerUser(int Id)
        {


            var response = await _ResellerUserService.GetResellerUserDetailesById(Id)
;
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateResellerUser(ResellerUserVM request)
        {
            try
            {

                // _logger.LogInformation("CreateCategory Action initiated");
                var response = _ResellerUserService.EditResellerUser(request);
                var Id = request.ResellerAdminUserId;
                //_logger.LogInformation("CreateCategory Action initiated");
                return RedirectToAction("ViewResellerUsers", new { id = Id });
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An error occurred while updating the OrganizationUser");
                return StatusCode(500, "Internal server error");
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
