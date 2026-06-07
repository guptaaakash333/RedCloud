using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RedCloud.Interfaces;
using RedCloud.Services;
using RedCloud.ViewModel;
using static RedCloud.Custom_Action_Filter.NoCacheAttribute;

namespace RedCloud.Controllers
{
    [AdminAuthorizationFilter]
    public class TemplateController : Controller
    {
        private readonly ITemplateService _templateService;
       
        private readonly ILogger<TemplateController> _logger;



        public TemplateController(ITemplateService templateService, ILogger<TemplateController> logger)
        {
            _templateService = templateService;
            _logger = logger;

        }

  

        [HttpGet]
        public async Task<IActionResult> ViewTemplates()
        {
            _logger.LogInformation("ViewTemplate Action initiated");
            var model = await _templateService.GetAllTemplates();
            _logger.LogInformation("ViewTemplate Action completed");
            return View(model);
        }


        public async Task<IActionResult> ViewTemplateDetails(int id)
        {


            _logger.LogInformation($"Fetching ViewTemplateDetails with ID: {id}");
            var response = await _templateService.GetTemplateById(id);
            if (response == null)
            {
                _logger.LogWarning($"ViewTemplateDetails with ID: {id} not found");
                return NotFound();
            }

            return View(response);

        }


        public async Task<IActionResult> AddTemplate()
        {
           var sessionId = HttpContext.Session.GetInt32("UserId");
            var model = new TemplateVM
            {
                SessionId = (int)sessionId
            };
            return View(model);


            //ViewBag.ResellerList = (await _reSellerAdminService.GetallResellerAdmin()).Select(r => r.ResellerName).ToList();
            //return View(); 


        }

        [HttpPost]
        public async Task<IActionResult> AddTemplate(TemplateVM request)
        {
            // _logger.LogInformation("CreateCategory Action initiated");

            
            var response = await _templateService.CreateTemplate(request);

            //_logger.LogInformation("CreateCategory Action initiated");
            return RedirectToAction("ViewTemplates");

            // return RedirectToAction("AddOrganizationAdmin", request);


        }

        public async Task<IActionResult> UpdateTemplate(int Id)
        {

            
            ViewBag.ID = HttpContext.Session.GetInt32("UserId");
            var response = await _templateService.GetTemplateById(Id);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTemplate(TemplateVM request)
        {
         
            try
            {
                // _logger.LogInformation("CreateCategory Action initiated");
                var response = _templateService.EditTemplate(request);

                //_logger.LogInformation("CreateCategory Action initiated");
                return RedirectToAction("ViewTemplates");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> SoftDeleteTemplate(int id)
        {
            try
            {
                await _templateService.DeleteTemplate(id);
                return Ok($"OrganizationDetails has been soft deleted.");
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Error occurred while soft deleting OrganizationDetails with ID {id}: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
