using Microsoft.AspNetCore.Mvc;
using MvcApiCallingService.Helpers.ApiHelper;
using RedCloud.Application.Features.Numbers.Commands;
using RedCloud.Application.Features.Numbers.Queries;
using RedCloud.Application.Features.ResellerAdminuser.Queries;
using RedCloud.Domain.Entities;
using RedCloud.Interfaces;
using RedCloud.ViewModel;

namespace RedCloud.Services
{
    //RedCloud.Application.Features.Numbers.Queries.ViewAssignedNumberVM
    public class NumberService <T> : INumberService<T> where T : class
    {

        private readonly IApiClient<NumberVM> _client;
        private readonly IApiClient<AssignNumberViewModel> _clientassign;
        private readonly IApiClient<NumberlistVM> _viewassign;
        private readonly IApiClient<RedCloud.Application.Features.Numbers.Queries.ViewAssignedNumberVM> _assign;
        public readonly ILogger<NumberService<T>> _logger;


        public NumberService(IApiClient<NumberVM> client, IApiClient<NumberlistVM> viewassign, ILogger<NumberService<T>> logger, IApiClient<AssignNumberViewModel> clientassign, IApiClient<RedCloud.Application.Features.Numbers.Queries.ViewAssignedNumberVM> assign)
        {
            _client = client;
            _logger = logger;
            _clientassign = clientassign;
            _assign = assign;
            _viewassign= viewassign;
        }
       
        public  async Task<int> AddNumber(NumberVM numberVM)
        {
            var users = await _client.PostAsync("Number/AddNumber", numberVM);
           
            return users.Data;
        }

     
        public async Task<AssignNumberViewModel> GetNumberById(int eventId)
        {
            // _logger.LogInformation("GetEventById Service initiated");
            var Events = await _clientassign.GetByIdAsync("Number/" + eventId);
            //_logger.LogInformation("GetEventById Service conpleted");
            return Events.Data;
        }

        public async Task UpdateNumber(AssignNumberViewModel assignNumberViewModel )
        {
            var id = assignNumberViewModel.NumberId;
            await _client.PutAsync($"Number/UpdateNumbers/{id}", assignNumberViewModel);
            //return users.Data;
        }

       
        public async Task<RedCloud.Application.Features.Numbers.Queries.ViewAssignedNumberVM> GetAssignedNumberById(int eventId)
        {
            var assignednumber = await _assign.GetByIdAsync("Number/Viewassignednumber/" + eventId);
            return assignednumber.Data;
        }

        public async Task UpdateAssignedNumber(RedCloud.Application.Features.Numbers.Queries.ViewAssignedNumberVM assignNumberViewModel)
        {
            var users = _client.PutAsync("Number/UpdateAssignedNumber", assignNumberViewModel);
            //return users.Data;
        }

        public async Task<IEnumerable<NumberlistVM>> Getallnumberslist()
        {
            var reSelleradmin = await _viewassign.GetAllAsync("Number/all");
            return reSelleradmin.Data;
        }

        public async Task UpdateProgress(NumberlistVM numberlistVM)
        {
            var id=numberlistVM.NumberId;
            var users =await  _client.PutAsync($"Number/UpdateStatus/{id}", numberlistVM);
        }
    }
}
