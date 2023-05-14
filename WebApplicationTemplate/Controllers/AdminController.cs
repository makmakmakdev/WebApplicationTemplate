using System;
using System.Threading.Tasks;
using DataLibrary.Dtos;
using Ldap;
using Ldap.Dtos;
using Ldap.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplicationTemplate.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            Console.WriteLine("Admin/index");

            return View();
        }

        [Route("Login")]
        [HttpGet]
        public IActionResult Login([FromForm] LdapLoginParameterDto data)
        {
            Ldap.Ldap ldap = new Ldap.Ldap("http://172.17.14.171:9008");

            var response = ldap.Login(data);

            LdapEmployeeModel domainAccountDetails = response.Data;

            if (HttpContext.Session.GetString("EmployeeNo") != null)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login([FromForm] LoginParameterDto requestData)
        {
            HttpContext.Session.SetString("EmployeeNo", requestData.Username);

            var returnUrl = HttpContext.Session.GetString("ReturnUrl");

            if (!string.IsNullOrEmpty(returnUrl))
            {
                HttpContext.Session.Remove("ReturnUrl");

                return Redirect(returnUrl);
            }

            return RedirectToAction("Index");
        }

        [Route("Logout")]
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}
