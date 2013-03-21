using System;
using System.Globalization;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AAULAN.Models
{
    public partial class Event
    {
        private readonly DatabaseReposity _repo = new DatabaseReposity();
        public SelectList GameList()
        {
            var gameList = new List<Games> {new Games()};
            gameList.AddRange(_repo.GetAllGames().ToList());

            var values = from g in gameList
                         select new {Id = g.ID, g.Name};

            return new SelectList(values, "Id", "Name", Games);
        }
        public SelectList LanList()
        {
            var lanList = new List<LAN>();
            lanList.AddRange(_repo.GetAllLans().ToList());

            var values = from g in lanList
                         select new { Id = g.ID, Name = g.StartTime.Month + "/" + g.StartTime.Year.ToString(CultureInfo.InvariantCulture) };

            return new SelectList(values, "Id", "Name", LAN);
        }

        
        private bool _isFoodEvent;
        public bool IsFoodEvent
        {
            get { return _isFoodEvent; }
            set { _isFoodEvent = value; }
        }


        public int TimeToStart()
        {
            return (int)(EndTime - DateTime.Now).TotalSeconds;
        }
    }

}