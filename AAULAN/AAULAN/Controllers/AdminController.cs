using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using AAULAN.Models;
using AAULAN.ViewModels;

namespace AAULAN.Controllers
{
    public class AdminController : Controller
    {
        readonly DatabaseReposity _repo = new DatabaseReposity();
        
        #region User
        #region RoleAssignment
        #region GET
        [HttpGet]
        [Authorize(Roles="Administrator, Crew")]
        public ActionResult RoleAssignment()
        {
            var viewModel = new UserViewModel
                {
                Users = _repo.GetAllUsers().ToList()
            };

            return View("../User/RoleAssignment",viewModel);
        }
        #endregion
        #endregion

        #region SeatingPlanning
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult SeatingPlanning()
        {
            var viewModel = _repo.GetAllSeatingPlans();

            return View("../User/SeatingPlanning", viewModel);
        }
        #endregion

        #region POST
        [HttpPost]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult SeatingPlanning(string submitButton, string id, string seatId)
        {
            switch (submitButton)
            {
                case "Add":
                    var newSeat = new Seat {SeatingPlanId = int.Parse(id)};
                    _repo.AddSeat(newSeat);
                    return Redirect("../Admin/SeatingPlanning");
                default:
                    return null;
            }
        }
        #endregion
        #region POST
        [HttpPost]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult SeatingPlanningSeat(string submitButton, string id, string seatId)
        {
            switch (submitButton)
            {
                case "Remove":
                    _repo.DeleteSeat(int.Parse(seatId));
                    return Redirect("../Admin/SeatingPlanning");
                case "Remove User From Seat":
                    Seat getSeat = _repo.GetSeatFromId(int.Parse(seatId));
                    getSeat.Taken = false;
                    getSeat.User = null;
                    _repo.UpdateSeat(getSeat);
                    return Redirect("../Admin/SeatingPlanning");
                default:
                    return null;
            }
        }
        #endregion
        #endregion

        #region SeatingChart
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew, User")]
        public ActionResult SeatingChart(int a=0)
        {
            if (a!=0)
            {
                var seat = _repo.GetSeatingPlanFromLanId(_repo.GetCurrentLan().ID).Seats[a-1];
                if (!seat.Taken)
                {
                    seat.Taken = true;
                    var user = _repo.GetUserFromUsername(ControllerContext.HttpContext.User.Identity.Name);
                    if (!_repo.UserHasSeat(user.Username))
                    {
                        _repo.UpdateSeat(seat, user);
                        var message = new MailMessage();
                        message.To.Add("aaulan@s-et.aau.dk"); //user.Email.Trim());
                        message.Subject = "Seat Confirmed";
                        message.From = new MailAddress("no-reply@aaulan.dk");
                        message.Body = seat.Id.ToString(CultureInfo.InvariantCulture);
                        var mailer = new SmtpClient
                            {
                                Host = "192.38.55.147",
                                Port = 57599
                            };
                        //mailer.Send(message);
                    }
                }
                else
                {
                    if(seat.User.Username.Trim() == ControllerContext.HttpContext.User.Identity.Name)
                    {
                        seat.Taken = false;
                        _repo.UpdateSeat(seat, null);
                    }
                }
                return Redirect("../Admin/SeatingChart");
            }
            

            var viewModel = new SeatingViewModel();
            viewModel.MakeSeats();
            viewModel.Seats = _repo.GetSeatingPlanFromLanId(_repo.GetCurrentLan().ID).Seats;


            var picBackground = Image.FromFile(Server.MapPath("../Content/SeatingArragnment.png"));
            var bgWid = picBackground.Width;
            dynamic bgHgt = picBackground.Height;
            var bgBm = new Bitmap(bgWid, bgHgt);        


            var picForeground = Image.FromFile(Server.MapPath("../Content/red.png"));
            var fgWid = picForeground.Width;
            dynamic fgHgt = picForeground.Height;
            var fgBm = new Bitmap(fgWid, fgHgt);

            var picForeground2 = Image.FromFile(Server.MapPath("../Content/green.png"));
            var fgBm2 = new Bitmap(fgWid, fgHgt);


            ColorMatrix zColor = new ColorMatrix();
            zColor.Matrix33 = (float)50 / 255.0f;
            var zAttrib = new ImageAttributes();
            zAttrib.SetColorMatrix(zColor);

            using (var gr = Graphics.FromImage(fgBm))
            {
                gr.DrawImage(picForeground, new Rectangle(0, 0, fgWid, fgHgt),0,0,fgBm.Width,fgBm.Height,GraphicsUnit.Pixel, zAttrib);
            }
            using (var gr = Graphics.FromImage(fgBm2))
            {
                gr.DrawImage(picForeground2, new Rectangle(0, 0, fgWid, fgHgt), 0, 0, fgBm2.Width, fgBm2.Height, GraphicsUnit.Pixel, zAttrib);
            }

            using (var gr = Graphics.FromImage(bgBm))
            {
                gr.DrawImage(picBackground, 0, 0, bgWid, bgHgt);
                gr.CompositingMode = CompositingMode.SourceOver;
                
                var i = 0;
                foreach (var point in viewModel.MappingTable)
                {
                    var cx = point.Coord.X; //Cordinated of X of 2nd image
                    var cy = point.Coord.Y; //Cordinates of Y of 2nd image

                    gr.DrawImage(viewModel.Seats[i].Taken ? fgBm2 : fgBm, cx, cy, point.Dim.X, point.Dim.Y);
                    if (viewModel.Seats[i].User != null)
                    {
                        if (viewModel.Seats[i].User.Username.Trim() == ControllerContext.HttpContext.User.Identity.Name)
                        {
                            gr.DrawString("X", new Font(new FontFamily("Arial"), 16.0f), Brushes.Black, cx+point.Dim.X/5-2, cy+point.Dim.Y/6-4);
                        }
                    }
                    i++;
                }
            }

            bgBm.Save(Server.MapPath("../Content/SeatingComplete.png"), System.Drawing.Imaging.ImageFormat.Png);
            fgBm.Dispose();

            return View("../User/SeatingChart", viewModel);
        }
        #endregion
        #endregion

        #region PromoteOrDemote
        #region POST
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult PromoteOrDemote(string submitButton, string username)
        {
            switch (submitButton)
            {
                case "Promote":
                    _repo.Promote(username);
                    return RedirectToAction("RoleAssignment");
                case "Demote":
                    _repo.Demote(username);
                    return RedirectToAction("RoleAssignment");
                case "Delete":
                    _repo.DeleteUser(username);
                    return RedirectToAction("RoleAssignment");
                default:
                    return null;
            }
        }
        #endregion
        #endregion

        #region SearchUsername
        #region POST
        [HttpPost]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult SearchUsername(string username)
        {
            var viewModel = new UserViewModel
                {
                Users = _repo.GetUsersByUsername(username).ToList()
            };

            return View("../User/RoleAssignment", viewModel);
        }
        #endregion
        #endregion
        #endregion

        #region Lan

        #region CreateLan
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult CreateLan()
        {
            var viewModel = new LanViewModel {Lan = new LAN {StartTime = DateTime.Now, EndTime = DateTime.Now}};

            return View("../Lan/CreateLan",viewModel);
        }
        #endregion

        #region POST
        [HttpPost]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult CreateLan(LanViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _repo.AddLan(viewModel.Lan);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }
        #endregion
        #endregion

        #region DeleteLan
        #region GET
        [HttpGet]
        public ActionResult DeleteLan(int id)
        {
            _repo.DeleteLan(id);
            return RedirectToAction("AllLans", "Admin");
        }
        #endregion
        #endregion

        #region AllLans
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult AllLans()
        {
            var viewModel = _repo.GetAllLans();
            return View("../Lan/AllLans", viewModel);
        }
        #endregion
        #endregion
        #endregion

        #region Event
        #region CreateEvent
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult CreateEvent()
        {
            var viewModel = new Event {StartTime = DateTime.Now, EndTime = DateTime.Now};


            return View("../Event/Event", viewModel);
        }
        #endregion

        #region POST
        [HttpPost]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult CreateEvent(Event viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.IsFoodEvent)
                {
                    var lastOrDefault = _repo.GetAllEvents().Where(s => s.FoodID != null).ToList().LastOrDefault();
                    if (lastOrDefault != null)
                        viewModel.FoodID = lastOrDefault.FoodID + 1;
                }
                if (viewModel.GAMEID == 0)
                    viewModel.GAMEID = null;
                _repo.AddEvent(viewModel);
                return RedirectToAction("Index", "Home");
            }

            return View("../Event/Event", viewModel);
        }
        #endregion
        #endregion

        #region DeleteEvent
        #region GET
        [HttpGet]
        public ActionResult DeleteEvent(int id)
        {
            _repo.DeleteEvent(id);
            return RedirectToAction("AllEvents","Admin");
        }
        #endregion
        #endregion

        #region AllEvents
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult AllEvents()
        {
            var viewModel = _repo.GetAllEvents();
            return View("../Event/AllEvents", viewModel);
        }
        #endregion
        #endregion
        #endregion

        #region Game
        #region CreateGame
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult CreateGame()
        {
            var viewModel = new Games();

            return View("../Game/Game", viewModel);
        }
        #endregion

        #region POST
        [HttpPost]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult CreateGame(Games viewModel)
        {
            if (ModelState.IsValid)
            {
                    _repo.AddGame(viewModel);
                    return RedirectToAction("Index", "Home");
            }
            return View("../Game/Game", viewModel);
            //return RedirectToAction("CreateGame", "Admin");
        }
        #endregion
        #endregion

        #region AllGames
        #region GET
        [HttpGet]
        public ActionResult AllGames()
        {
            var viewModel = _repo.GetAllGames();
            return View("../Game/AllGames", viewModel);
        }
        #endregion
        #endregion
        #endregion
    }
}
