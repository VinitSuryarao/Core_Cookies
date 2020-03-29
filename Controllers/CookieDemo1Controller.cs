using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookieManager;
using CookiesDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CookiesDemo.Controllers
{
    public class CookieDemo1Controller : Controller
    {
        #region Create Cookie Manager Object By DI
        public ICookieManager CookieManager { get; set; }
        #endregion

        #region Create Constructor For DI
        public CookieDemo1Controller( ICookieManager CookieManager)
        {
            this.CookieManager = CookieManager;
        }
        #endregion

        #region Set Model Property
        [BindProperty]
        public ViewClientModel ViewClientModel { get; set; }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OnSubmit()
        {
            //Json Convert
            var clientModelJson = JsonConvert.SerializeObject(ViewClientModel.ClientModel);

            // Store User Model data into Cookies
            CookieManager.Set("ClientModelData", clientModelJson);

            return base.RedirectToAction("Index", "CookieDemo2");
        }
    }
}