using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AAULAN.Models;
using AAULAN.ViewModels;

namespace AAULAN.Controllers
{
    public class OrderController : Controller
    {
        readonly DatabaseReposity _repo = new DatabaseReposity();

        #region Index
        #region GET
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new OrderViewModel();
            if (ControllerContext.HttpContext.User.Identity.IsAuthenticated)
                viewModel.Mad = new Mad {Name = ControllerContext.HttpContext.User.Identity.Name};
            return View(viewModel);
        }
        #endregion

        #region POST
        [HttpPost]
        public ActionResult Index(OrderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(viewModel.Mad.Name))
                    return RedirectToAction("Status", new {status = 3});

                if (viewModel.Mad.Number < 1 || viewModel.Mad.Number > 101)
                {
                    return RedirectToAction("Status", new {status = 2});
                }
                viewModel.Mad.Number = viewModel.Mad.Number;
                viewModel.Mad.Paid = false;
                var accepted = _repo.AddOrder(viewModel.Mad);

                return RedirectToAction("Status", accepted ? new {status = 0} : new {status = 1});
            }
            return View("../Order/Index", viewModel);
        }

        #endregion
        #endregion

        #region Status
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult Status(int status)
        {
            var viewModel = new Mad();

            switch (status)
            {
                case 0:
                    viewModel.X= "Confirmed - SKAL BETALES - NU!";
                    break;
                case 1:
                    viewModel.X = "Denied - There is no such event";
                    break;
                case 2:
                    viewModel.X = "Denied - Out of range exeption";
                    break;
                case 3:
                    viewModel.X = "Denied - Motherfucker haz name?!";
                    break;
            }

            return View(viewModel);
        }
        #endregion
        #endregion

        #region CreatePizza
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public  ActionResult CreatePizza()
        {
            var viewModel = new Pizza();
            return View("../Order/CreatePizza", viewModel);
        }
        #endregion
        #region POST
        [HttpPost]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult CreatePizza(Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                _repo.AddPizza(pizza);
                return RedirectToAction("AllPizzas");
            }
            return View("../Order/CreatePizza", pizza);
        }
        #endregion
        #endregion

        #region AllPizzas
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public  ActionResult AllPizzas()
        {
            var viewModel = new OrderViewModel
                {
                    Prices = _repo.GetAllPizzas().ToList()
                };
            return View("../Order/AllPizzas", viewModel);
        }
        #endregion
        #region POST
        [HttpPost]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult AllPizzas(OrderViewModel viewModel)
        {
            if (ModelState.IsValid)
                _repo.AddPizza(viewModel.Pizza);

            viewModel = new OrderViewModel
                {
                    Prices = _repo.GetAllPizzas().ToList()
                };
            return View("../Order/AllPizzas", viewModel);
        }
        #endregion
        #endregion

        #region AllOrders
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult AllOrders()
        {
            var viewModel = new OrderViewModel
                {
                Orders = _repo.GetAllOrders().ToList(),
                Prices = _repo.GetAllPizzas().ToList()
            };
            return View("../Order/AllOrders", viewModel);
        }
        #endregion

        #region POST
        [HttpPost]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult AllOrders(OrderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateOrders(viewModel.Orders);
                return RedirectToAction("AllOrders");
            }
            return View("../Order/AllOrders", viewModel);
        }
        #endregion

        #region AllOrdersWith ID
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult AllOrdersWithId(OrderViewModel viewModel)
        {
            if (viewModel == null) viewModel = new OrderViewModel();
            if (viewModel.Mad.EVENTID == 0)
                return RedirectToAction("AllOrders");

            viewModel.Orders = _repo.GetAllOrdersWithId(viewModel.Mad.EVENTID).ToList();
            viewModel.Prices = _repo.GetAllPizzas().ToList();
            return View("../Order/AllOrders", viewModel);
        }
        #endregion
        #endregion
        #endregion

        #region DeleteOrder
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult DeleteOrder(int id)
        {
            _repo.DeleteOrder(id);
            return RedirectToAction("AllOrders");
        }
        #endregion
        #endregion

        #region GetTotalOrders
        #region GET
        [Authorize(Roles = "Administrator, Crew")]
        [HttpGet]
        public ActionResult GetTotalOrder(OrderViewModel viewModel)
        {
            if (viewModel != null)
            {
                var allFood = _repo.GetAllOrdersWithId(viewModel.Mad.EVENTID).OrderBy(s => s.Number).ToList();
                var totalFood = new List<Mad>();
                var checkedIds = new List<int>();

                if (allFood.Count != 0)
                {
                    for (var i = 0; i < allFood.Count; i++)
                    {
                        var count = 1;
                        for (var x = i + 1; x < allFood.Count; x++)
                        {
                            if (allFood[i].Number != allFood[x].Number) continue;
                            if (allFood[x].Note == null && allFood[i].Note == null)
                            {
                                count++;
                                checkedIds.Add(x);
                            }
                            else if (allFood[x].Note != null && allFood[i].Note != null)
                            {
                                if (allFood[i].Note.ToLower() == allFood[x].Note.ToLower())
                                {
                                    count++;
                                    checkedIds.Add(x);
                                }
                            }
                        }

                        if (checkedIds.Contains(i)) continue;
                        var newMad = allFood[i];
                        newMad.Quantity = count;
                        totalFood.Add(newMad);
                    }
                }
                viewModel.Orders = totalFood;
                viewModel.Prices = _repo.GetAllPizzas().ToList();
            }

            return View("GetTotalOrder", viewModel);
        }
        #endregion
        #endregion
    }
}
