using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookieManager;
using CookiesDemo.Models;
using CookiesDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CookiesDemo.Controllers
{
    public class CookieDemo2Controller : Controller
    {
        #region Create Cookie Manager Object By DI
        public ICookieManager CookieManager { get; set; }
        #endregion

        #region Create Constructor For DI
        public CookieDemo2Controller(ICookieManager CookieManager)
        {
            this.CookieManager = CookieManager;
        }
        #endregion


        public IActionResult Index()
        {
            var clientModelJson = this.CookieManager.Get<String>("ClientModelData");

            var clientModel = JsonConvert.DeserializeObject<ClientModel>(clientModelJson);

            ViewBag.FirstName = clientModel.FirstName.ToString();
            ViewBag.LastName = clientModel.LastName.ToString();

            return View();
        }
    }
}