using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using TicketManagementSystem.Models;

namespace TicketManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly IEmailSender _emailSender;, IEmailSender emailSender


        public AccountController(UserManager<IdentityUser> userManager,
                                      SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_emailSender = emailSender;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Login user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

        //public IActionResult ForgotPassword()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // TODO: Send reset password link to the user's email.
        //        // Include a unique token in the link to identify the user.
        //        // The user clicks the link to access the reset password page.
        //        var user = await _userManager.FindByEmailAsync(model.Email);
        //        if (user != null)
        //        {
        //            // Generate and store a unique token (reset password token)
        //            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        //            // Generate a reset password link with the token
        //            var callbackUrl = Url.Action("ResetPassword", "Account",
        //                new { email = model.Email, token }, protocol: HttpContext.Request.Scheme);

        //            // Send the reset password link to the user's email
        //            await _emailSender.SendEmailAsync(model.Email, "Reset Password",
        //                $"Please reset your password by clicking <a href='{callbackUrl}'>here</a>.");


        //            ViewBag.SuccessMessage = "Password reset link sent successfully.";
        //        }
        //    }

        //    return View(model);
        //}

        //[HttpGet]
        //public IActionResult ResetPassword(string email, string token)
        //{
        //        var model = new ResetPasswordViewModel { Email = email , Token = token };
        //        return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByEmailAsync(model.Email);
        //        if (user != null)
        //        {
        //            // Reset the user's password using the provided token
        //            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
        //            if (result.Succeeded)
        //            {
        //                // Redirect to login page after successful password reset
        //                return RedirectToAction("Login", "Account");
        //            }
        //            else
        //            {
        //                foreach (var error in result.Errors)
        //                {
        //                    ModelState.AddModelError("", error.Description);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            // Handle the case when the user is not found
        //        }
        //    }

        //    return View(model);
        //}

    }
}
