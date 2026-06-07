using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RedCloud.Application.Features.AssignNumberToUser.Commands;
using RedCloud.Domain.Entities;
using RedCloud.Interfaces;
using RedCloud.ViewModel;

namespace RedCloud.Controllers
{
    public class AssignNumberToUserController : Controller
    {
        private readonly IAssignNumberService _assignNumberService;
        private readonly IMessagingUserService _messagingUserService;
        private readonly ILogger<AssignNumberToUserController> _logger;

        public AssignNumberToUserController(IAssignNumberService assignNumberService, ILogger<AssignNumberToUserController> logger, IMessagingUserService messagingUserService)
        {
            _assignNumberService = assignNumberService;
            _logger = logger;
            _messagingUserService = messagingUserService;

        }

        [HttpGet]
        public async Task<IActionResult> ViewAllAssignNumberToUser()
        {
            var response = await _assignNumberService.GetAllAssignNumber();

            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAssignNumberById(int id)
        {
            var response = await _assignNumberService.GetAssignNumberById(id);

            return View(response);
        }

        //[HttpGet]
        //public async Task<IActionResult> AssignNumber(int id)
        //{
        //    var MsgUsers = await _messagingUserService.GetAllMessagingUsers();

        //    ViewBag.MsgUsers = new SelectList(MsgUsers, "MessagingUserId", "MessagingUserFirstName");
        //    var response = await _assignNumberService.GetAssignNumberById(id);
        //    return View(response);
        //}

        [HttpGet]
        public async Task<IActionResult> AssignNumber(int id)
        {
            var MsgUsers = await _messagingUserService.GetAllMessagingUsers();
            ViewBag.MsgUsers = new SelectList(MsgUsers, "MessagingUserId", "MessagingUserFirstName");
            ViewBag.MsgUserList = MsgUsers;
            var response = await _assignNumberService.GetAssignNumberById(id);
            return View(response);

           
        }

        [HttpPost]
        public async Task<IActionResult> AssignNumber(AssignNumberToUserVM model)
        {
            return RedirectToAction("ViewAllAssignNumberToUser");
        }


    }
}
