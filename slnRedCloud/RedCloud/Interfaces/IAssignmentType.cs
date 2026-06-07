using RedCloud.Application.Features.AssignmentType;

namespace RedCloud.Interfaces
{
    public interface IAssignmentType<T>
    {
        Task <IEnumerable<AssignmentTypeVM>> Getallassignments();
    }
}
