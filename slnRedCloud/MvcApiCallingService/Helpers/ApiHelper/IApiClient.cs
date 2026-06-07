
using MvcApiCallingService.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApiCallingService.Helpers.ApiHelper
{
    public interface IApiClient<T>
    {
        Task<Response<List<T>>> GetListByIdAsync(string apiUrl);
        Task<Response<IEnumerable<T>>> GetAllAsync(string apiUrl);
        Task<PagedResponse<IEnumerable<T>>> GetPagedAsync(string apiUrl);
        Task<Response<T>> GetByIdAsync(string apiUrl);
        //change  return type to int
        Task<Response<int>> PostAsync<TEntity>(string apiUrl, TEntity entity);
        // for Account

        Task<Response<T>> PostAuthAsync<TEntity>(string apiUrl, TEntity entity); //Change by Akash
        //Below orignnal
        //Task<T> PostAuthAsync<TEntity>(string apiUrl, TEntity entity);
        Task<Response<T>> PutAsync<TEntity>(string apiUrl, TEntity entity);
        Task<string> DeleteAsync(string apiUrl);

        Task<Response<T>> PutAsyncc<TEntity>(string apiUrl, TEntity entity);

       // Task<Response<T>> EncryptGetByIdAsync(string id);//Atharva




    }
}
