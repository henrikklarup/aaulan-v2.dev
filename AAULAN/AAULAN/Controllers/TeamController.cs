using System.Linq;
using System.Web.Mvc;
using AAULAN.Models;
using AAULAN.ViewModels;

namespace AAULAN.Controllers
{
    public class TeamController : Controller
    {
       
        readonly DatabaseReposity _repo = new DatabaseReposity();
        
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew, User")]
        public ActionResult AllTeams()
        {
            var viewModel = _repo.GetAllTeams();
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Crew, User")]
        public ActionResult AllTeams(int teamId, string teamPassword)
        {
            var getTeam = _repo.GetTeamById(teamId);
            var getUser = _repo.GetUserFromUsername(HttpContext.User.Identity.Name.Trim());
            if (!getTeam.StandaloneTeam)
            {
                if (getTeam.Password == teamPassword)
                {
                    _repo.AddTeamMemberToTeam(getTeam, getUser.TeamMember ?? new TeamMember{User = _repo.GetUserFromUsername(ControllerContext.HttpContext.User.Identity.Name.Trim())});
                }
            }
            return RedirectToAction("AllTeams");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Crew, User")]
        public ActionResult AllGameEvents()
        {
            var viewModel = _repo.GetAllFutureEvents(_repo.GetCurrentLan().ID).Where(s=>s.GAMEID != null);
            return View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Crew, User")]
        public ActionResult SignUp()
        {

            var viewModel = new EventViewModel
                {
                    Events = _repo.GetAllFutureEvents(_repo.GetCurrentLan().ID).ToList(),
                    Teams = _repo.GetTeamMembersTeams(_repo.GetUserFromUsername(ControllerContext.HttpContext.User.Identity.Name.Trim()).TeamMember).ToList()
                };
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Crew, User")]
        public ActionResult SignUp(int eventId, string teamIds)
        {
            var teamId = int.Parse(teamIds);
            if (ModelState.IsValid)
            {
                var firstOrDefault = _repo.GetAllEvents().FirstOrDefault(s => s.ID == eventId);
                if (firstOrDefault != null)
                {
                    var x = firstOrDefault.Team.FirstOrDefault(s => s.Id == teamId);
                    if(x == null)
                        _repo.AddTeamToEvent(_repo.GetTeamById(teamId),_repo.GetAllEvents().FirstOrDefault(s => s.ID == eventId));
                }
                return RedirectToAction("AllGameEvents");
            }

            var viewModel = new EventViewModel
            {
                Events = _repo.GetAllFutureEvents(_repo.GetCurrentLan().ID).ToList()
            };
            return View(viewModel);
        }

        [Authorize(Roles = "Administrator, Crew, User")]
        [HttpGet]
        public ActionResult CreateTeam()
        {
            var viewModel = new Team();
            return View(viewModel);
        }

        [Authorize(Roles = "Administrator, Crew, User")]
        [HttpPost]
        public ActionResult CreateTeam(Team team)
        {
            var getTeam = from e in _repo.GetAllTeams()
                          where e.Name == team.Name
                          select e;
            if (getTeam.Any())
            {
                return View(team);
            }
            var getTeamMember = (from e in _repo.GetAllTeamMembers()
                                 where
                                     e.User.Username.Trim() ==
                                     ControllerContext.HttpContext.User.Identity.Name.Trim()
                                 select e).FirstOrDefault() ?? new TeamMember
                                     {
                                         User = _repo.GetUserFromUsername(ControllerContext.HttpContext.User.Identity.Name.Trim())
                                     };
            _repo.AddTeam(team);
            _repo.AddTeamMemberToTeam(team, getTeamMember);


            return RedirectToAction("AllTeams");
        }
    }
}
