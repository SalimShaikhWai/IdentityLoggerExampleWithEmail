using Demo63Assignment.Models.Interface;
using Demo63Assignment.Models.Service;
using Demo63Assignment.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo63Assignment.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ICrudService<DepartmentViewModel> _crudDepartmentService;

        public DepartmentsController(ICrudService<DepartmentViewModel> crudDepartmentService)
        {
            _crudDepartmentService = crudDepartmentService;
           
        }

        public async Task<IActionResult> IndexAsync()
        {
          var departmentViewModel= await _crudDepartmentService.GetAllAsync();
            return View(departmentViewModel);  
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateAsync(DepartmentViewModel department)
        {
            if(ModelState.IsValid)
            {
                await _crudDepartmentService.CreateAsync(department);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

    }
}
