using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Application.Features.AssignmentType;
using RedCloud.Interfaces;
using RedCloud.ViewModel;

namespace RedCloud.Services
{
    public class AssignmentType<T> : IAssignmentType<T> where T : class
    {

        private readonly IApiClient<AssignmentTypeVM> _client;
        public readonly ILogger<AssignmentType<T>> _logger;


        public AssignmentType(IApiClient<AssignmentTypeVM> client, ILogger<AssignmentType<T>> logger)
        {
            _client = client;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IEnumerable<AssignmentTypeVM>> Getallassignments()
        {
            _logger.LogInformation("Getallassignmenttype Service initiated");
            var assignmenttype = await _client.GetAllAsync("AssignmentType/all");
            _logger.LogInformation("Getallassignmenttype Service conpleted");
            return assignmenttype.Data;

        }

       
    }
}
