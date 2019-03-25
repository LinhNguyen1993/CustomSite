using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CustomSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CustomSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private IConfiguration _config;
        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IEmailSender emailSender,
            IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            try
            {
                if (result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account",
                        values: new { userId = user.Id, code = HttpUtility.UrlEncode(code) },
                        protocol: Request.Scheme);
                    var template = "Please confirm your account by " + "<a href='" + callbackUrl + "'>Click here</a>";
                    await _emailSender.SendEmailAsync(model.Email, "Confirm your email", template);

                    return Ok();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return BadRequest();
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, HttpUtility.UrlDecode(code));
            if (result.Succeeded)
            {
                var request = HttpContext.Request;
                string baseUrl = request.Scheme + "://" + request.Host.Value;
                return Redirect(baseUrl);
            }

            return BadRequest(new InvalidOperationException($"Error confirming email for user with ID '{userId}'"));
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            IActionResult response = Unauthorized();

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email,
                    model.Password, model.Remember, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var tokenString = GenerateJSONWebToken(result);
                    response = Ok(new { token = tokenString });
                }
            }
            return response;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            IActionResult response = BadRequest();

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var callbackUrl = HandleCallBackUrl("ResetPassword", "Account", new { userId = user.Id, code = HttpUtility.UrlEncode(code) });
                    var template = "Reset password " + "<a href='" + callbackUrl + "'>Click here</a>";
                    await _emailSender.SendEmailAsync(model.Email, "Reset password", template);

                    response = Ok();
                }
            }

            return response;
        }

        private string GenerateJSONWebToken(object info)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtIssuerOptions:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["JwtIssuerOptions:Issuer"],
              _config["JwtIssuerOptions:Audience"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string HandleCallBackUrl(string actionName, string controllerName, object values)
        {
            var callbackUrl = Url.Action("ResetPassword", "Account",
                        values: values,
                        protocol: Request.Scheme);

            return callbackUrl;
        }
    }
}