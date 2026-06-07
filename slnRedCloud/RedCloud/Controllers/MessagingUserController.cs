using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RedCloud.Application.Features.MessagingUsers.Commands;
using RedCloud.Domain.Entities;
using RedCloud.Interfaces;
using RedCloud.Services;
using RedCloud.ViewModel;

namespace RedCloud.Controllers
{
    public class MessagingUserController : Controller
    {
        private readonly IMessagingUserService _messagingUserService;
        private readonly ILogger<MessagingUserController> _logger;



        public MessagingUserController(IMessagingUserService messagingUserService, ILogger<MessagingUserController> logger)
        {
            _messagingUserService = messagingUserService;
            _logger = logger;

        }

     

        [HttpGet]
        public async Task<IActionResult> ViewMessagingUsers(int Id)
        {
            //_logger.LogInformation("ViewOrganizationAdmin Action initiated");
            var model = await _messagingUserService.GetAllMessagingUsers();
            //_logger.LogInformation("ViewOrganizationAdmin Action completed");
            return View(model);
        }


        public async Task<IActionResult> ViewMessagingUserDetails(int id)
        {


            //_logger.LogInformation($"Fetching ViewOrganizationDetails with ID: {id}");
            var response = await _messagingUserService.GetMessagingUserById(id);
            if (response == null)
            {
                _logger.LogWarning($"ViewOrganizationDetails with ID: {id} not found");
                return NotFound();
            }

            return View(response);

        }



        [HttpPut]
        public async Task<IActionResult> BlockMessagingUser(int id)
        {
            try
            {
                var response = await _messagingUserService.BlockMessagingUser(id);
                return Json(new { success = true, message = "Successfully blocked the Messaging User " + response.MessagingUserFirstName });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while blocking the Messaging User." });
            }
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> AddMessagingUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMessagingUser(MessagingUser messaginguser)
        {
            var result = await _messagingUserService.AddMessagingUser(messaginguser);

            return RedirectToAction("ViewMessagingUsers");
            
            return View(messaginguser);
        }


        [HttpGet]
        public async Task<IActionResult> EditMessagingUser(int Id)
        {
            var response = await _messagingUserService.GetMessagingUserById(Id);
            return View(response);
        }


        [HttpPost]
        public async Task<IActionResult> EditMessagingUser(UpdateMessagingUserQuery updatemessaginguserquery)
        {
            if (ModelState.IsValid)
            {
                
                var resposne = await _messagingUserService.UpdateMessagingUser(updatemessaginguserquery) ;
            }
            return RedirectToAction("ViewMessagingUsers");
        }
    }
}
