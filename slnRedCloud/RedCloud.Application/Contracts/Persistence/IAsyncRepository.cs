using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Application.Contract.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid Id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);

        Task<T> GetByIdAsync(int Id);

        Task<T> GetByIdAsyncInculde(int id);

        Task<IList<T>> StoredProcedureQueryAsync(string storedProcedureName, SqlParameter[] parameters = null);//Atharva
        Task<IList<T>> StoredProcedureQueryAsync(string storedProcedureName);//Atharva


        //For Insert, Update, Delete Operations
        Task<int> StoredProcedureCommandAsync(string storedProcedureName, SqlParameter[] parameters = null);//Atharva

      
        Task<List<T>> GetAllIncludeAsync();

        
    }
}
