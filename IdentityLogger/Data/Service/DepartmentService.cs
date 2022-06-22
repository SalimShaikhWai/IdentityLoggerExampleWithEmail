using AutoMapper;
using Demo63Assignment.Models.Interface;
using Demo63Assignment.Models.UtilityClass;
using Demo63Assignment.Models.ViewModel;
using IdentityLogger.Data;
using Microsoft.EntityFrameworkCore;

namespace Demo63Assignment.Models.Service
{

    public class DepartmentService : ICrudService<DepartmentViewModel>, IDepartmentService
    {
        private readonly ApplicationDbContext _userMgtContext;

        private readonly IMapper _mapper;
        public DepartmentService(ApplicationDbContext userMgtContext, IMapper mapper)
        {
            _userMgtContext = userMgtContext;
            _mapper = mapper;
        }
        public async Task CreateAsync(DepartmentViewModel entity)
        {
            var department = _mapper.Map<Department>(entity);
            await _userMgtContext.Departments.AddAsync(department);
            await _userMgtContext.SaveChangesAsync();
        }
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DepartmentViewModel>> GetAllAsync()
        {
            var departments = await _userMgtContext.Departments.ToListAsync();
            var departmentViewModel = departments.Select(x => _mapper.Map<DepartmentViewModel>(x)).ToList();
            return departmentViewModel;

        }

        public Task<DepartmentViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DropDown>> GetDepartmentForDropDown()
        {
            var list = await _userMgtContext.Departments.Select(d => new DropDown { Id = d.Id, Name = d.Name }).ToListAsync();
            return list;
        }

        public Task Update(DepartmentViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
