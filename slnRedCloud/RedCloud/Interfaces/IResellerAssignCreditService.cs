using RedCloud.Application.Features.Reseller.AssignCredit.Queries;
using RedCloud.Domain.Entities;
using RedCloud.ViewModel;

namespace RedCloud.Interfaces
{
	public interface IResellerAssignCreditService
	{
		Task<IEnumerable<OrganizationAdmin>> GetOrganizationAdminList();
		Task<IEnumerable<CreditsType>> GetCreditsTypeList();
		Task<int> AddRate(RateAssignCreditVM model);
		Task<RateAssignCreditVM> EditRate(RateAssignCreditVM model);
		Task<RateAssignCreditVM> GetRateById(int Id);
		Task<IEnumerable<GetAllAssignCredit>> GetAllAssignCredit();

		Task<AssignCreditDetailsVM> GetAssignCreditDetails(int id);

		Task<GetRatedUsage> GetRatedUsageDetailsById(int id);

    }
}
