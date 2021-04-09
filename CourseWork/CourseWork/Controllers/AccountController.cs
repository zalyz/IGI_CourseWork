using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CourseWork.Models.AccountModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using BLL.BusinessInterfaces;
using EntityModels.Users;
using System.Linq;

namespace CourseWork.Controllers
{
    public class AccountController : Controller
    {
        private readonly IService<Author> _authorService;

        public AccountController(IService<Author> authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AccountRegistrationValidation accountValidation)
        {
            if (ModelState.IsValid)
            {
                var author = new Author
                {
                    Name = accountValidation.Nickname,
                    Email = accountValidation.Email,
                    Password = accountValidation.Password,
                    Role = Role.Author,
                };

                author.Id = _authorService.Add(author);
                await Authenticate(author);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountAuthenticateValidation accountAuthenticate)
        {
            if (ModelState.IsValid)
            {
                var author = _authorService.GetAll()
                    .FirstOrDefault(e => e.Email == accountAuthenticate.Email &&
                    e.Password == accountAuthenticate.Password);
                if (author != null)
                {
                    await Authenticate(author);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "No such account");
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        private async Task Authenticate(Author author)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", author.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, author.Name),
                new Claim("Email", author.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, author.Role.ToString())
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public IActionResult ShowProfile()
        {
            var id = int.Parse(User.Claims.First(e => e.Type == "Id").Value);
            var author = _authorService.GetAll().First(e => e.Id == id);
            return View(author);
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            var id = int.Parse(User.Claims.First(e => e.Type == "Id").Value);
            var author = _authorService.GetAll().First(e => e.Id == id);
            return View(author);
        }

        [HttpPost]
        public IActionResult EditProfile(EditProfileViewModel editModel)
        {
            var author = _authorService.GetAll().First(e => e.Id == int.Parse(User.Claims.First(e => e.Type == "Id").Value));
            author.Name = editModel.Name;
            author.Email = editModel.Email;
            author.Description = editModel.Description;
            author.Phone = editModel.Phone;
            _authorService.Update(author);

            return RedirectToAction("ShowProfile");
        }
    }
}
