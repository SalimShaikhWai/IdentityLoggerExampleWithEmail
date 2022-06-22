using Demo63Assignment.Models.DataModel;
using Demo63Assignment.Models.Interface;
using Demo63Assignment.Models.Service;
using Demo63Assignment.Models.UtilityClass;
using Demo63Assignment.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Demo63Assignment.Controllers
{
    public class UsersController : Controller
    {
        private readonly ICrudService<UserViewModel> _crudUserService;
        private readonly IUserService _userService;
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<UsersController> _logger;
        public UsersController(ICrudService<UserViewModel> crudService,
                IDepartmentService departmentService, IUserService userService, ILogger<UsersController> logger)
        {
            _crudUserService = crudService;
            _departmentService = departmentService;
            _userService = userService;
            _logger = logger;
        }
        public async Task<IActionResult> IndexAsync(int pageNumber = 1)
        {
            // var userData = await _crudUserService.GetAllAsync();
            var data = await _userService.PagingGetAllAsync(pageNumber);
            _logger.LogWarning("Index page access");
            return View(data);
        }
        [Authorize]
        public async Task<ActionResult> Create()
        {

            ViewBag.Departments = await GetSelectListDepartmentAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Create(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_userService.IsUnique(user.Pan, user.Email))
                    {
                        ModelState.AddModelError(String.Empty, "Pan Or Email is Allready used");
                        throw new Exception("Unique Key Constraints");
                    }
                    await _crudUserService.CreateAsync(user);
                    //int d = 0;
                    //var ans = 5 / d;
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Some error occure while creating User");
                    //ModelState.AddModelError(String.Empty, "Can not create user this time");
                }
                ViewBag.Departments = await GetSelectListDepartmentAsync(user.DepartmentRefId);


            }
            return View();
        }
        public async Task<SelectList> GetSelectListDepartmentAsync(int? id = null)
        {
            var departmentViewModel = await _departmentService.GetDepartmentForDropDown();
            if (id == null)
                return new SelectList(departmentViewModel, "Id", "Name");
            else
                return new SelectList(departmentViewModel, "Id", "Name", id);
        }
        [Authorize]
        public async Task<ActionResult> Update(int id)
        {
            var userViewModel = await _crudUserService.GetByIdAsync(id);
            if (userViewModel == null)
                return RedirectToAction(nameof(Index));

            ViewBag.Departments = await GetSelectListDepartmentAsync(userViewModel.Id);

            return View(userViewModel);
        }
        [Authorize]
        public async Task<ActionResult> UpdateUser(UserViewModel userViewModel)
        {
            await _crudUserService.Update(userViewModel);
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var userViewModel = await _crudUserService.GetByIdAsync(id);
            return View(userViewModel);
        }
        [Authorize]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _crudUserService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
