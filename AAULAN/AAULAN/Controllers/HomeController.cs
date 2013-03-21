using System;
using System.Linq;
using System.Web.Mvc;
using AAULAN.Models;
using AAULAN.ViewModels;

namespace AAULAN.Controllers
{
    public class HomeController : Controller
    {
        readonly DatabaseReposity _repo = new DatabaseReposity();

        #region Index
        #region GET
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new EventViewModel();
            try
            {
                var id = _repo.GetCurrentLan().ID;

                viewModel.Events = _repo.GetAllFutureEvents(id).ToList();
            }
            catch (Exception)
            {
                return View();
            }

            return View(viewModel);
        }
        #endregion
        #endregion
    }
}
