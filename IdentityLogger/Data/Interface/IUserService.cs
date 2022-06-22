using Demo63Assignment.Models.DataModel;
using Demo63Assignment.Models.UtilityClass;
using Demo63Assignment.Models.ViewModel;

namespace Demo63Assignment.Models.Interface
{
    public interface IUserService
    {
        public Task<PaginatedList<Employee, UserViewModel>> PagingGetAllAsync(int pageNumber);
        public bool IsUnique(string Pan, string email);

    }
}
