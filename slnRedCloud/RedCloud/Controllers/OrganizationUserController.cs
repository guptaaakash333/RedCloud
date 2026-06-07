using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RedCloud.Custom_Action_Filter;
using RedCloud.Interfaces;
using RedCloud.ViewModel;
using static RedCloud.Custom_Action_Filter.NoCacheAttribute;

namespace RedCloud.Controllers
{

    public class OrganizationUserController : Controller
    {
        private readonly IOrganizationUserService _organizationUserService;
        private readonly IOrganizationAdminService _organizationAdminService;
        private readonly ILogger<OrganizationUserController> _logger;
      


        public OrganizationUserController(IOrganizationUserService organizationUserService, ILogger<OrganizationUserController> logger)
        {
            _organizationUserService = organizationUserService;
            _logger = logger;
            
        }

        // AAKASh
            
        [HttpGet]
        public async Task<IActionResult> ViewOrganizationUsers(int Id)
        {
            TempData["OrganizationUserId"] = Id;
            //_logger.LogInformation("ViewOrganizationAdmin Action initiated");
            //var model = await _organizationUserService.GetAllOrganizationUser().Where(x => x.OrganizationAdminId == Id).ToList(); 
            var model = (await _organizationUserService.GetAllOrganizationUser()).Where(x => x.OrganizationAdminId == Id).ToList();
            //_logger.LogInformation("ViewOrganizationAdmin Action completed");
            return View(model);
        }


        public async Task<IActionResult> ViewOrganizationUserDetails(int id)
        {

           
            //_logger.LogInformation($"Fetching ViewOrganizationDetails with ID: {id}");
            var response = await _organizationUserService.GetOrganizationUserDetailesById(id);
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
                var response = await _organizationUserService.BlockOrganizationUser(id);
                return Json(new { success = true, message = "Successfully blocked the Organization Admin " + response.OrganizationUserFirstName });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while blocking the OrganizationAdmin." });
            }
        }


        // ---------------------------------------------------------------------------------

        public async Task<IActionResult> AddOrganizationUser()
        {
            
                var id = (int)TempData["OrganizationUserId"];
                var model = new OrganizationUserVM()
                {
                    OrganizationAdminId = id
                };
                return View(model);
            

            //ViewBag.ResellerList = (await _reSellerAdminService.GetallResellerAdmin()).Select(r => r.ResellerName).ToList();
            //return View(); 

            
        }

        [HttpPost]
        public async Task<IActionResult> AddOrganizationUser(OrganizationUserVM request)
        {
            // _logger.LogInformation("CreateCategory Action initiated");


            var response = await _organizationUserService.CreateOrganizationUser(request);
            var Id = request.OrganizationAdminId;

            //_logger.LogInformation("CreateCategory Action initiated");
            return RedirectToAction("ViewOrganizationUsers", new { id = Id });

            
        }

        public async Task<IActionResult> UpdateOrganizationUser(int Id)
        {

            var response = await _organizationUserService.GetOrganizationUserDetailesById(Id);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrganizationUser(OrganizationUserVM request)
        {
            //// _logger.LogInformation("CreateCategory Action initiated");
            //var response = _organizationUserService.EditOrganizationUser(request);
            //var Id = request.OrganizationAdminId;
            ////_logger.LogInformation("CreateCategory Action initiated");
            //return RedirectToAction("ViewOrganizationUsers", new { id = Id });
            try
            {
                await _organizationUserService.EditOrganizationUser(request);
                var id = request.OrganizationAdminId;
                return RedirectToAction("ViewOrganizationUsers", new { id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the OrganizationUser");
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
