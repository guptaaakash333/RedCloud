using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RedCloud.Application.Features.AssignmentType;
//using RedCloud.Application.Features.Campaign;
using RedCloud.Application.Features.Numbers.Commands;
using RedCloud.Application.Features.Numbers.Queries;
using RedCloud.Application.Features.ResellerAdminuser.Queries;
using RedCloud.Custom_Action_Filter;
using RedCloud.Domain.Entities;
using RedCloud.Interfaces;
using RedCloud.Services;
using RedCloud.ViewModel;
using System.ComponentModel.Design;
using static RedCloud.Custom_Action_Filter.NoCacheAttribute;
//using CampaignVM = RedCloud.Application.Features.Campaign.CampaignVM;

namespace RedCloud.Controllers
{

    public class NumberController : Controller
    {
        private readonly IDropDownService<CountryVM> _dropDownService;
        private readonly IStateService<StateVM> _stateService;
        private readonly ICarrier<CarrierVM> _carrier;
        private readonly IType<TypesVM> _type;
        private readonly INumberService<NumberVM> _numberService;
        private readonly IAssignmentType<AssignmentTypeVM> _assignmentType;
        private readonly IAdminResellerUser _adminResellerUser;
        private readonly IOrganizationAdminService _organizationAdminService;//take getall from aakash 
        private readonly ICampaign<CampaignVM> _campaign;
        private readonly INumberService<RedCloud.Application.Features.Numbers.Queries.ViewAssignedNumberVM> _numberServiceVM;
        // private readonly IMapper _mapper;
        private readonly INumberService<NumberlistVM> _numberService2;


        public NumberController(IDropDownService<CountryVM> dropDownService,
        INumberService<RedCloud.Application.Features.Numbers.Queries.ViewAssignedNumberVM> numberServiceVM, IOrganizationAdminService organizationAdminService, ICampaign<CampaignVM> campaign, IAdminResellerUser adminResellerUser, IStateService<StateVM> stateService, ICarrier<CarrierVM> carrier, IType<TypesVM> type, INumberService<NumberVM> numberService, IAssignmentType<AssignmentTypeVM> assignmentType, INumberService<NumberlistVM> numberService2)
        {
            _dropDownService = dropDownService;
            _stateService = stateService;
            _carrier = carrier;
            _type = type;
            _numberService = numberService;
            _assignmentType = assignmentType;
            _adminResellerUser = adminResellerUser;
            _organizationAdminService = organizationAdminService;
            _campaign = campaign;
            _numberServiceVM = numberServiceVM;
            _numberService2 = numberService2;


        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddNumber()

        {
            var carrierlist = await _carrier.GetAllCarriersList();
            ViewBag.AdminList = new SelectList(carrierlist, "CarrierId", "CarrierName");
            var countries = await _dropDownService.GetAllCountryList();
            ViewBag.Country = countries;
            var typelist = await _type.GetAllTypesList();
            ViewBag.Typelist = new SelectList(typelist, "TypesId", "TypesName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNumber(NumberVM Model)
        {

            var response = await _numberService.AddNumber(Model);//name of service and service method

            return RedirectToAction("AddNumber");
        }

        public async Task<IActionResult> AssignNumber(int Id)
        {


            var response = await _numberService.GetNumberById(Id);
            var resellerList = await _adminResellerUser.GetallResellerAdmin();
            ViewBag.ResellerList = new SelectList(resellerList, "ResellerAdminUserId", "ResellerName");
            var campaignlist = await _campaign.GetallCampaignlist();
            ViewBag.Campaignlist = new SelectList(campaignlist, "CampaignId", "CampaignId");
            var assignmenttype = await _assignmentType.Getallassignments();
            ViewBag.Assignmenttype = new SelectList(assignmenttype, "AssignmentTypeId", "AssignmentTypeName");
            var orgadmin = await _organizationAdminService.GetAllOrganizationAdmins();
            ViewBag.Orgadmin = new SelectList(orgadmin, "OrgID", "OrgName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> AssignNumber(AssignNumberViewModel request)
        {
            var response = _numberService.UpdateNumber(request);
            return RedirectToAction("Viewallnumberslist");
        }





        [HttpGet]
        public async Task<IActionResult> Viewassignednumber(int id)
        {
            var response = await _numberServiceVM.GetAssignedNumberById(id);
            return View(response);
        }


        public async Task<IActionResult> UpdateAssignedNumber(int Id)
        {


            var response = await _numberServiceVM.GetAssignedNumberById(Id);//changed numberServiceVM to numberservice
            var carrierlist = await _carrier.GetAllCarriersList();
            ViewBag.AdminList = new SelectList(carrierlist, "CarrierId", "CarrierName");
            var countries = await _dropDownService.GetAllCountryList();
            ViewBag.Country = countries;
            ViewBag.State = await _stateService.GetStatesByCountryId(response.CountryId ?? 0);
            var typelist = await _type.GetAllTypesList();
            ViewBag.Typelist = new SelectList(typelist, "TypesId", "TypesName");
            var resellerList = await _adminResellerUser.GetallResellerAdmin();
            ViewBag.ResellerList = new SelectList(resellerList, "ResellerAdminUserId", "ResellerName");
            var campaignlist = await _campaign.GetallCampaignlist();
            ViewBag.Campaignlist = new SelectList(campaignlist, "CampaignId", "CampaignId");
            var assignmenttype = await _assignmentType.Getallassignments();
            ViewBag.Assignmenttype = new SelectList(assignmenttype, "AssignmentTypeId", "AssignmentTypeName");
            var orgadmin = await _organizationAdminService.GetAllOrganizationAdmins();
            ViewBag.Orgadmin = new SelectList(orgadmin, "OrgID", "OrgName");

            return View(response);
        }



        [HttpPost]
        public async Task<IActionResult> UpdateAssignedNumber(RedCloud.Application.Features.Numbers.Queries.ViewAssignedNumberVM request)
        {
            // _logger.LogInformation("CreateCategory Action initiated");
            var response = _numberService2.UpdateAssignedNumber(request);

            return RedirectToAction("Viewallnumberslist");
        }

        [HttpGet]
        public async Task<IActionResult> GetNumberById(int id)
        {
            var response = await _numberServiceVM.GetAssignedNumberById(id);
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> Viewallnumberslist()
        {
            //_logger.LogInformation("ViewResellerAdmin Action initiated");
            var response = await _numberServiceVM.Getallnumberslist();
            //_logger.LogInformation("ViewResellerAdmin Action completed");
            return View(response);
        }




        public async Task<IActionResult> UpdateProgress(int Id)
        {
            var response = await _numberServiceVM.GetNumberById(Id);

            var number = new NumberlistVM()
            {
                NumberId = Id,
                Status = response.Status ?? Status.InProgress,
            };
            return View(response);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateProgress(NumberlistVM number)

        {
            var response = _numberService2.UpdateProgress(number);
            return RedirectToAction("GetNumberById");

        }


        //public async Task<IActionResult> UpdateProgressnew(int id)
        //{
        //    var response = await _numberServiceVM.GetNumberById(id);
        //    var model = new NumberlistVM()
        //    {
        //        NumberId = id,
        //        Status = response.Status ?? Status.InProgress,
        //    };
        //    return PartialView("_UpdateProgressPartial", model); // Return a partial view
        //}

        //[HttpPost]
        //public async Task<IActionResult> UpdateProgressnew(NumberlistVM number)
        //{
        //    var response =  _numberService2.UpdateProgress(number);
        //    if (response.IsCompleted)
        //    {
        //        return Json(new { success = true });
        //    }
        //    else
        //    {
        //        return Json(new { success = false});
        //    }
        //}


//        [HttpPost]
//        [RequestSizeLimit(10000000)] // Limit to 10 MB
//        public async Task<IActionResult> SingleFileUpload(IFormFile SingleFile)
//        {
//            if (SingleFile == null || SingleFile.Length == 0)
//            {
//                ModelState.AddModelError("", "File not selected");
//                return View("Index");
//            }
//            var permittedExtensions = new[] { ".jpg", ".png", ".gif" };
//            var extension = Path.GetExtension(SingleFile.FileName).ToLowerInvariant();
//            if (string.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
//            {
//                ModelState.AddModelError("", "Invalid file type.");
//            }
//            // Optional: Validate MIME type as well
//            var mimeType = SingleFile.ContentType;
//            var permittedMimeTypes = new[] { "image/jpeg", "image/png", "image/gif" };
//            if (!permittedMimeTypes.Contains(mimeType))
//            {
//                ModelState.AddModelError("", "Invalid MIME type.");
//            }
//            if (ModelState.IsValid)
//            {
//                //Creating a unique File Name
//                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(SingleFile.FileName);
//                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", uniqueFileName);
//                //Using Buffering
//                //using (var stream = System.IO.File.Create(filePath))
//                //{
//                //    // The file is saved in a buffer before being processed
//                //    await SingleFile.CopyToAsync(stream);
//                //}
//                //Using Streaming
//                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
//                {
//                    //This will save to Local folder
//                    await SingleFile.CopyToAsync(stream);
//                }
//                // Create an instance of FileModel
//                var fileModel = new Number
//                {
//                    FileName = uniqueFileName,
//                    Length = SingleFile.Length,
//                    ContentType = mimeType,
//                    Data = ConvertToByteArray(filePath)
//                };
//                // Save to database
//                EFCoreDbContext _context = new EFCoreDbContext();
//                _context.Files.Add(fileModel);
//                await _context.SaveChangesAsync();
//                // Process the file here (e.g., save to the database, storage, etc.)
//                return View("UploadSuccess");
//            }
//            return View("Index");
//        }
//        //This method will convert the uploaded file into byte array
//        private byte[] ConvertToByteArray(string filePath)
//        {
//            byte[] fileData;
//            //Create a File Stream Object to read the data
//            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
//            {
//                using (BinaryReader reader = new BinaryReader(fs))
//                {
//                    fileData = reader.ReadBytes((int)fs.Length);
//                }
//            }
//            return fileData;
//        }
//    }
//}
    }
}