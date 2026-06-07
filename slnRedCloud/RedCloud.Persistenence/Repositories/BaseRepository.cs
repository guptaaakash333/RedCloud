using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using RedCloud.Application.Contract.Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Persistenence.Repositories
{
    //[ExcludeFromCodeCoverage]
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public BaseRepository(ApplicationDbContext dbContext, ILogger<T> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public virtual async Task<T> GetByIdAsync(Guid Id)
        {
            return await _dbContext.Set<T>().FindAsync(Id)
  ;
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            try
            {
                return await _dbContext.Set<T>().FindAsync(Id);
            }
            catch (Exception)
            {

                throw;
            }
       
        }
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            try
            {
                _logger.LogInformation("ListAllAsync Initiated");
                return await _dbContext.Set<T>().ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<List<T>> GetAllIncludeAsync()
        {
            try
            {
                var query = _dbContext.Set<T>().AsQueryable();

                var entityType = _dbContext.Model.FindEntityType(typeof(T));
                var navigationProperties = entityType.GetNavigations();

                foreach (var navigationProperty in navigationProperties)
                {
                    query = query.Include(navigationProperty.Name);
                }

                return await query.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }



        public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
        {
            return await _dbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        //For Read Operation
        public async Task<IList<T>> StoredProcedureQueryAsync(string storedProcedureName, SqlParameter[] parameters = null)
        {
            var parameterNames = GetParameterNames(parameters);
            return await _dbContext.Set<T>().FromSqlRaw(string.Format("{0} {1}", storedProcedureName, string.Join(",", parameterNames)), parameters).ToListAsync();
        }
		public async Task<IList<T>> StoredProcedureQueryAsync(string storedProcedureName)
		{
			return await _dbContext.Set<T>().FromSqlRaw(string.Format("{0}", storedProcedureName)).ToListAsync();
		}

		//For Insert, Update, Delete Operations
		public async Task<int> StoredProcedureCommandAsync(string storedProcedureName, SqlParameter[] parameters = null)
        {
            var parameterNames = GetParameterNames(parameters);
            return await _dbContext.Database.ExecuteSqlRawAsync(string.Format("{0} {1}", storedProcedureName, string.Join(",", parameterNames)), parameters);
            
        }

        private string[] GetParameterNames(SqlParameter[] parameters)
        {
            var parameterNames = new string[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                parameterNames[i] = parameters[i].ParameterName;
            }
            return parameterNames;
        }

        
        //Eager Loading of Related Data   ---------------------------

        public async Task<T> GetByIdAsyncInculde(int id)
        {
            try
            {
                var query = _dbContext.Set<T>().AsQueryable();

                var entityType = _dbContext.Model.FindEntityType(typeof(T));
                var primaryKeyProperty = entityType.FindPrimaryKey().Properties.First().Name;

                var navigationProperties = entityType.GetNavigations();

                foreach (var navigationProperty in navigationProperties)
                {
                    query = query.Include(navigationProperty.Name);
                }

                return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, primaryKeyProperty) == id);
            }
            catch (Exception)
            {

                throw;
            }

        }


        //public async Task<IList<T>> StoredProcedureQueryAsync(string storedProcedureName)// Atharva
        //{
        //    //var parameterNames = GetParameterNames(parameters);
        //    return await _dbContext.Set<T>().FromSqlRaw(string.Format("{0}", storedProcedureName)).ToListAsync();
        //}

        
    }


}

