using AutoMapper.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Newtonsoft.Json;
using RedCloud.Application.Contract.Infrastructure;
using RedCloud.Application.Features.Account.Queries.LoginQuery;
using RedCloud.Application.Helper;
using RedCloud.Custom_Action_Filter;
using RedCloud.Domain.Common;
using RedCloud.Domain.Entities;
using RedCloud.Interfaces;
using RedCloud.Models.Email;
using RedCloud.ViewModel;
using System.Net.Http;
using System.Text;

namespace RedCloud.Controllers
{

    //[NoCache]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMailService _mailService;
        private readonly IDistributedCache _distributedCache;
        private readonly IEncryptionService _encryptionService;

        public AccountController(IAccountService accountService, IMailService mailService, IDistributedCache distributedCache, IEncryptionService encryptionService)
        {
            _accountService = accountService;
            _mailService = mailService;
            _distributedCache = distributedCache;
        }


        // Action method to display the login page

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Action method to handle login POST requests
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {

                //to convert the plain text into encrypted password
                //LoginVM loginData = new LoginVM()
                //{
                //    Email = model.Email,
                //    Password = EncryptionDecryption.DecryptString(model.Password)
                //};


                //var data = loginData;

                // Here you would call your API to valIdate the credentials
                //var result =await _accountService.Login(loginData);

                //correct code below 
                var result = await _accountService.Login(model);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "InvalId login attempt.");
                    return View(model);

                }
                if (result.Data.Roles != null)
                {
                    // Set session data
                    var roles = result.Data.Roles.Select(r => new
                    {
                        RoleName = r.RoleName.Trim(),
                        // Include other properties if needed
                    });
                    HttpContext.Session.SetString("Email", result.Data.Email);
                    HttpContext.Session.SetInt32("UserId", result.Data.UserId);
                    HttpContext.Session.SetString("UserRoles", JsonConvert.SerializeObject(roles));
                    HttpContext.Session.SetInt32("UserId", result.Data.UserId);


                    var RoleName = result.Data.Roles[0].RoleName;

                    HttpContext.Session.SetString("Role", RoleName);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "InvalId login attempt.");
                }
            }
            return View(model);
        }

        public IActionResult SetRole(string roleName)
        {
            // Set the session variable to the provIded role name
            HttpContext.Session.SetString("Role", roleName);

            ViewBag.role = HttpContext.Session.GetString("Role");

            if (HttpContext.Session.GetString("Role") == "Sub Admin Administrator")
            {
                return PartialView("_SubAdmin", ViewBag.role);
            }
            else if (HttpContext.Session.GetString("Role") == "Reseller Admin")
            {
                return PartialView("_ResellerAdmin", ViewBag.role);
            }
            else if (HttpContext.Session.GetString("Role") == "Organization Admin")
            {
                return PartialView("_OrganizationAdmin", ViewBag.role);
            }
            else if (HttpContext.Session.GetString("Role") == "Messaging Users")
            {
                return PartialView("_MessagingUsers", ViewBag.role);
            }

            return RedirectToAction("Index", "Home");
        }

        //ForgetUserPasswordVM
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetUserPasswordVM model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("Email", "Email is required.");
                return View();
            }
            else
            {
                var IsUserExist = await _accountService.CheckUserExistByEmail(model.Email);


                if (IsUserExist == null)
                {
                    ModelState.AddModelError("Email", "Please enter valid Email");
                    return View();
                }
                else
                {
                    int originalValue = IsUserExist.UserId;
                    string encryptedValue = _encryptionService.EncryptValue(originalValue);

                    MailRequest mailRequest = new MailRequest()
                    {
                        ToEmail = model.Email,
                        Subject = "Forget Password",
                        //Body = $"This Forget email password please click  https://localhost:7206/Account/ResetPassword"
                        //Body = $"This Forget email password please click  https://localhost:7206/Account/ResetPassword/{data[0].userId}"
                        //Body = $"This Forget email password please click  https://localhost:7206/Account/ResetUserPassword/{IsUserExist.UserId}"
                        //Body = $"This Forget email password please click  {EncrptedUrl}"
                        //Body = $"This Forget email password please click  https://localhost:7206/Account/ResetUserPassword/{EncrptedUrl}"
                        Body = $"This Forget email password please click  https://localhost:7206/Account/ResetUserPassword/?strUserId={encryptedValue}"
                    };
                    await _mailService.SendEmailAsync(mailRequest);
                    //var responses = await _accountService.ForgetUserPasswordService(model);

                    // Return to the same view with a success message
                    TempData["SuccessMessage"] = "Email sent successfully! Please check on mail";

                }

            }
            return View();
        }
        public async Task<IActionResult> ResetUserPassword(string strUserId)
        {
            int UserId = _encryptionService.DecryptValue(strUserId);
            ViewBag.UserId = UserId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetUserPassword(ResetUserPasswordVM model)
        {
            ViewBag.UserId = model.UserId;
            if (ModelState.IsValid)
            {
                model.Password = EncryptionDecryption.EncryptString(model.Password);
                var response = await _accountService.ForgetUserPasswordService(model);
                TempData["SuccessMessage"] = "Password Reset successfully!l";
            }
            else
            {
                TempData["ErrorMessage"] = "Please try again!";
            }
            return View();
        }
        /*
        public async Task<IActionResult> ResetUserPassword(int Id)
        {
            ViewBag.UserId = Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetUserPassword(ResetUserPasswordVM model)
        {

            if (ModelState.IsValid)
            {
               var response = await _accountService.ForgetUserPasswordService(model);

               if (response.Succeeded == false)
                {
                    
                    return View();
                }                
                else
                {

                    //_notyf.Error(loginResponse.Message);
                    return View();
                }
<<<<<<<<< Temporary merge branch 1

=========
            
            }

            //var apiUrl = $"https://localhost:7193/api/Account/ResetPassword";

            //using (HttpClient client = new HttpClient())
            //{
            //    // Serialize the model object to JSON
            //    string jsonModel = JsonConvert.SerializeObject(model);

            //    StringContent content = new StringContent(jsonModel, Encoding.UTF8, "application/json");

            //    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        // Handle successful API response
            //        return RedirectToAction("Login", "Account"); // Redirect to another action (optional)
            //    }
            //    else
            //    {
            //        // Handle API call failures
            //        ModelState.AddModelError("", $"API call failed with status code: {response.StatusCode}");
            //        return View();
            //    }
            //}
            TempData["ErrorMessage"] = "Please try again!";
            return View();
        }
        */
        //[NoCache]
        [HttpGet]
        public ActionResult Logout()
        {
            // Clear all session data
            HttpContext.Session.Clear();

            // Remove specific session items if still present (though Clear() should have removed them)
            HttpContext.Session.Remove("UserName");
            HttpContext.Session.Remove("UserRoles");
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("Email");

            // Setting no-cache headers to ensure the browser does not cache the pages
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            // Redirect to the Login action of the Account controller          
            // return RedirectToAction("Login", "Account");
            return RedirectToActionPermanent("Login", "Account");


        }

    }

}
