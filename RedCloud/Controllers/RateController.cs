using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RedCloud.Application.Features.Rates.Commands;
using RedCloud.Application.Features.Rates.Queries;
using RedCloud.Application.Helper;
using RedCloud.Custom_Action_Filter;
using RedCloud.Domain.Entities;
using RedCloud.Interfaces;
using RedCloud.ViewModel;
using static RedCloud.Custom_Action_Filter.NoCacheAttribute;

namespace RedCloud.Controllers
{
    [NoCache]
    [AdminAuthorizationFilter]
    public class RateController : Controller
    {
        private readonly ILogger<RateController> _logger;
        private readonly IRate _rate;
        private readonly IAdminResellerUser _adminreseller;
        private readonly IHttpContextAccessor _httpContextAccessor;



        public RateController(ILogger<RateController> logger, IRate rate, IAdminResellerUser adminreseller, IHttpContextAccessor httpContextAccessor)
        {
            _rate = rate;
            _logger = logger;
            _adminreseller = adminreseller;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> ViewallRates()
         {

            var response = await _rate.GetallRate();

            return View(response);
        }

        public async Task<IActionResult> GetRateByID(int id)

        {
            _logger.LogInformation($"Fetching Rate with ID: {id}");
            var response = await _rate.GetRateId(id);


            if (response == null)
            {
                _logger.LogWarning($"Rate with ID: {id} not found");
                return NotFound();
            }

            return View(response);
        }
        //[HttpGet]
        //public async Task<IActionResult> GetRateByID(string encryptedId)
        //{
        //    try
        //    {
        //        var response = await _rate.GetRateByEncryptedId(encryptedId);

        //        if (response == null)
        //        {
        //            _logger.LogWarning($"Rate with ID: {encryptedId} not found");
        //            return NotFound();
        //        }

        //        return View(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Error fetching rate: {ex.Message}");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}




        public async Task<IActionResult> DeleteRate(int id)
        {
            _logger.LogInformation($"Fetching Rate with ID: {id}");
            var response = await _rate.SoftDeleteById(id);


            if (response == null)
            {
                _logger.LogWarning($"Rate with ID: {id} not found");
                return NotFound();
            }

            return RedirectToAction("ViewallRates");
        }


        //[HttpGet]
        //public IActionResult AddRate()
        //{
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> AddRate()
        {

            var resellers = await _rate.GetResellersAsync();


            ViewBag.Resellers = new SelectList(resellers, "ResellerAdminUserId", "ResellerName");

            return View();
        }






        [HttpPost]
        public async Task<IActionResult> AddRate(Rate rate)
        {

            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {

                return RedirectToAction("Login", "Account");
            }

            rate.CreatedBy = userId;
            rate.CreatedDate = DateTime.Now;

            var result = await _rate.AddRate(rate);

              return RedirectToAction("ViewallRates");


            return View(rate);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateRate(int id)
        {
            _logger.LogInformation($"Fetching Rate with ID: {id}");
            var response = await _rate.GetRateId(id);

            if (response == null)
            {
                _logger.LogWarning($"Rate with ID: {id} not found");
                return NotFound();
            }

            var resellers = await _rate.GetResellersAsync();
            ViewBag.Resellers = new SelectList(resellers, "ResellerAdminUserId", "ResellerName");
            return View(response);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateRate(UpdateRateVm model)
        {
            var updateRateCommand = new UpdateRateCommand
            {
                RateId = model.RateId,
                //ResellerName = model.ResellerName,
                ResellerAdminUserId = model.ResellerAdminUserId,
                MonthlyNumber = model.MonthlyNumber,
                Users = model.Users,
                InboundSMS = model.InboundSMS,
                OutboundSMS = model.OutboundSMS,
                InboundMMS = model.InboundMMS,
                OutboundMMS = model.OutboundMMS,
                Type = model.Type
               
            };
            

                try
                {
                    var response = await _rate.UpdateRate(updateRateCommand);
                    if (response)
                    {
                        return RedirectToAction("ViewallRates");
                    }

                   
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error updating rate: {ex.Message}");
                    ModelState.AddModelError("", "Internal server error");
                }

                var resellersList = await _rate.GetResellersAsync();
                ViewBag.Resellers = new SelectList(resellersList, "ResellerAdminUserId", "ResellerName");
            return RedirectToAction("ViewallRates");
        }

        }
    }















