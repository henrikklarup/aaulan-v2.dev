using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AAULAN.Models;

namespace AAULAN.ViewModels
{
    public class EventViewModel
    {
        private readonly DatabaseReposity _repo = new DatabaseReposity();
        public List<Event> Events { get; set; }
        public List<Team> Teams { get; set; }

        public SelectList TeamList(TeamMember teamMember)
        {
            var teamList = new List<Team>();
            teamList.AddRange(_repo.GetTeamMembersTeams(teamMember).ToList());

            return new SelectList(teamList, "Id", "Name");
        }
    }
}