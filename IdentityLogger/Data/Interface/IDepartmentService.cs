using Demo63Assignment.Models.UtilityClass;

namespace Demo63Assignment.Models.Interface
{
    public interface IDepartmentService
    {
        public Task<List<DropDown>> GetDepartmentForDropDown();
    }
}
