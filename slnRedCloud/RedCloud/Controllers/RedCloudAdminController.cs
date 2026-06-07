using Microsoft.AspNetCore.Mvc;
using RedCloud.Application.Features.RedCloudAdmins.Commands.CreateRedCloudAdmin;
using RedCloud.Custom_Action_Filter;
using RedCloud.Domain.Entities;
using RedCloud.Interfaces;
using RedCloud.Services;
using static RedCloud.Custom_Action_Filter.NoCacheAttribute;

namespace RedCloud.Controllers
{
    [NoCache]
    [AdminAuthorizationFilter]
    public class RedCloudAdminController : Controller
    {

        private readonly IRedCloudAdminService _adminUserService;
        private readonly ILogger<RedCloudAdminService> _logger;

        public RedCloudAdminController(IRedCloudAdminService adminUserService, ILogger<RedCloudAdminService> logger)
        {
            _adminUserService = adminUserService;
            _logger = logger;
        }

        [HttpGet("AddAdminUser")]
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost("AddAdminUser")]
        public async Task<IActionResult> AddAdmin(RedCloudAdminVM request)
        {
            if (ModelState.IsValid)
            {
                var adminUser = new RedCloudAdmin
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    MobileNumber = request.MobileNumber,
                    IsActive = request.IsActive,
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = null,
                    IsDeleted = false
                };

                var response = await _adminUserService.CreateAdminUser(adminUser);
                return RedirectToAction("ViewallRedCloudAdmin");
            }
            return View(request);
        }

        public async Task<IActionResult> EditAdmin(int Id)
        {
            var response = await _adminUserService.GetAdminUserById(Id);
            return View(response);
        }


        [HttpPost]
        public async Task<IActionResult> EditAdmin(RedCloudAdminVM request)
        {
            if (ModelState.IsValid)
            {
                var adminUser = new RedCloudAdmin
                {
                    RedCloudAdminUserId = request.RedCloudAdminUserId,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    MobileNumber = request.MobileNumber,
                    IsActive = request.IsActive,
                    LastModifiedDate = DateTime.UtcNow,
                    LastModifiedBy = null
                };

                await _adminUserService.EditAdminUser(adminUser);
                return RedirectToAction("ViewallRedCloudAdmin");
            }
            return View(request);
        }


        [HttpGet]
        public async Task<IActionResult> ViewallRedCloudAdmin()
        {
            //_logger.LogInformation("ViewResellerAdmin Action initiated");
            var response = await _adminUserService.GetallRedCloudAdminUser();
            //_logger.LogInformation("ViewResellerAdmin Action completed");
            return View(response);
        }

        public async Task<IActionResult> GetRedCloudAdminByID(int id)
        {
            _logger.LogInformation($"Fetching ResellerAdmin with ID: {id}");
            var response = await _adminUserService.GetAdminUserById(id)
  ;

            if (response == null)
            {
                _logger.LogWarning($"ResellerAdmin with ID: {id} not found");
                return NotFound();
            }

            return View(response);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteRedCloudAdmin(int id)
        {
            try
            {
                await _adminUserService.SoftDeleteRedCloudAdmin(id);
                return Ok($"ResellerAdmin with ID {id} has been soft deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred while soft deleting ResellerAdmin with ID {id}: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Block(int id)
        {
            try
            {
                //var response = await _reSellerAdminService.GetResellerAdminById(id)
                ;

                //response.IsActive = false;
                var response = await _adminUserService.Block(id)
    ;
                return View(response);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while blocking the reseller." });
            }
        }

    }
}
