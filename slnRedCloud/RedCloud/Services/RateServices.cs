using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MvcApiCallingService.Helpers.ApiHelper;
using Newtonsoft.Json;
using RedCloud.Application.Features.Rates.Commands;
using RedCloud.Application.Features.Rates.Queries;
using RedCloud.Application.Features.ResellerAdminuser.Queries;
using RedCloud.Application.Helper;
using RedCloud.Domain.Entities;
using RedCloud.Interfaces;

namespace RedCloud.Services
{
    public class RateServices : IRate
    {

        private readonly IApiClient<Rate> _rate;
        private readonly IApiClient<GetRate> _rateuser;
        private readonly IApiClient<RateDetailVM> _client;
        private readonly IApiClient<ReSellerAdmindto> _resellerApiClient;

        public RateServices(IApiClient<Rate> rate, IApiClient<GetRate> rateuser, IApiClient<RateDetailVM> client, IApiClient<ReSellerAdmindto> resellerApiClient)
        {
            _client = client;
            _rate = rate;
            _rateuser = rateuser;
            _resellerApiClient = resellerApiClient;
        }
        public async Task<IEnumerable<GetRate>> GetallRate()
        {

            var ratr = await _rateuser.GetAllAsync("Rate");

            return ratr.Data;
        }

        public async Task<RateDetailVM> GetRateId(int id)
        {
            var rate = await _client.GetByIdAsync("Rate/" + id);
            return rate.Data;
        }

        //public async Task<RateDetailVM> GetRateByEncryptedId(string encryptedId)
        //{
        //    // Decrypt the encrypted ID
        //    //var decryptedId = EncryptionDecryption.DecryptString(encryptedId);

        //    //// Convert the decrypted ID to the appropriate type (e.g., int)
        //    //if (!int.TryParse(decryptedId, out int id))
        //    //{
        //    //    throw new ArgumentException("Invalid ID format");
        //    //}

        //    // Fetch data using the decrypted ID
        //    var rate = await _client.EncryptGetByIdAsync("Rate/" + encryptedId);

        //    return rate.Data;
        //}






        public async Task<bool> SoftDeleteById(int id)
        {
            var response = await _rate.DeleteAsync("Rate/" + id);
            return !string.IsNullOrEmpty(response);
        }


        public async Task<bool> AddRate(Rate rate)
        {
            var response = await _rate.PostAsync("Rate", rate);
            return response.Data > 0;
        }

        public async Task<IEnumerable<ReSellerAdmindto>> GetResellersAsync()
        {
            try
            {
                var response = await _resellerApiClient.GetAllAsync("ResellerAdminUser/all");

                if (response.Succeeded)
                {
                    var resellers = response.Data.Select(r => new ReSellerAdmindto
                    {
                        ResellerAdminUserId = r.ResellerAdminUserId,
                        ResellerName = r.ResellerName,

                    });

                    return resellers;
                }
                else
                {

                    return Enumerable.Empty<ReSellerAdmindto>();
                }
            }
            catch (Exception ex)
            {

                return Enumerable.Empty<ReSellerAdmindto>();
            }
        }



        public async Task<bool> UpdateRate(UpdateRateCommand updateRateCommand)
        {
            var response = await _rate.PutAsync("Rate/" + updateRateCommand.RateId, updateRateCommand);
            return response.Succeeded;
        }





    }


}
    






