using Edukator.EntityLayer.Concrete;
using Edukator.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Edukator.PresentationLayer.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Name = values.Name;
            userEditViewModel.Surname = values.Surname;
            userEditViewModel.ImageURL = values.ImageURL;
            userEditViewModel.Email = values.Email;
            userEditViewModel.UserName = values.UserName;
            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if(userEditViewModel.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(userEditViewModel.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/userimages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await userEditViewModel.Image.CopyToAsync(stream);
                user.ImageURL = "/userimages/" + imageName;
            }
            user.Name = userEditViewModel.Name;
            user.Surname = userEditViewModel.Surname;
            user.Email = userEditViewModel.Email;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }
    }
}
