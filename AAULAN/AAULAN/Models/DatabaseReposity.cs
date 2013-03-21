using System;
using System.Collections.Generic;
using System.Linq;


namespace AAULAN.Models
{
    public class DatabaseReposity
    {
        private readonly AAULANHOMEPAGEEntities1 _aauEnt = new AAULANHOMEPAGEEntities1();

        #region GET

        #region GetTeamMember

        public TeamMember GetTeamMember(User user)
        {
            return _aauEnt.TeamMemberSet.FirstOrDefault(s => s.User.Username == user.Username);
        }

        #endregion

        #region GetTeamMember

        public Team GetTeamById(int teamId)
        {
            return _aauEnt.TeamSet.FirstOrDefault(s => s.Id == teamId);
        }

        #endregion

        #region GetTeamMembersTeams

        public IQueryable<Team> GetTeamMembersTeams(TeamMember teamMember)
        {
            var x = from e in _aauEnt.TeamSet
                                 from a in e.TeamMember
                                 where a.Id == teamMember.Id
                                 select e;
            return x;
        }

        #endregion

        #region GetAllTeams

        public IQueryable<Team> GetAllTeams()
        {
            return _aauEnt.TeamSet;
        }

        #endregion

        #region GetAllTeamMembers

        public IQueryable<TeamMember> GetAllTeamMembers()
        {
            return _aauEnt.TeamMemberSet;
        }

        #endregion

        #region GetCurrentEvent

        public Event GetCurrentEvent()
        {
            IQueryable<Event> x = from e in GetAllEvents()
                                  where e.StartTime < DateTime.Now && e.EndTime > DateTime.Now && e.FoodID == null
                                  select e;
            return x.FirstOrDefault();
        }

        #endregion

        #region GetCurrentPizzaEvent
        public Event GetCurrentPizzaEvent()
        {
            IQueryable<Event> x = from e in GetAllEvents()
                                  where e.StartTime < DateTime.Now && e.EndTime > DateTime.Now && e.FoodID != null
                                  select e;
            return x.FirstOrDefault();
        }

        #endregion

        #region GetCurrentLan

        public LAN GetCurrentLan()
        {
            IQueryable<LAN> x = from e in GetAllLans()
                                where e.StartTime < DateTime.Now && e.EndTime > DateTime.Now
                                select e;
            return x.FirstOrDefault();
        }

        #endregion

        #region GetLanFromID

        public LAN GetLanFromId(int id)
        {
            return _aauEnt.LAN.FirstOrDefault(s => s.ID == id);
        }

        #endregion

        #region GetSeatFromID

        public Seat GetSeatFromId(int id)
        {
            return _aauEnt.Seat.FirstOrDefault(s => s.Id == id);
        }

        #endregion

        #region GetSeatingPlanFromLanId

        public SeatingPlan GetSeatingPlanFromLanId(int lanid)
        {
            IQueryable<SeatingPlan> x = from e in GetAllSeatingPlans()
                                        where e.LANID == lanid
                                        select e;
            return x.FirstOrDefault();
        }

        #endregion

        #region GetSeatsInSeatingPlan

        public IQueryable<Seat> GetSeatsInSeatingPlan(int seatingplanid)
        {
            return from e in _aauEnt.Seat
                   where e.SeatingPlanId == seatingplanid
                   select e;
        }

        #endregion

        #region GetGameFromId
        public Games GetGameFromId(int? gameId)
        {
            var x = GetAllGames().FirstOrDefault(s => s.ID == gameId);
            return x;
        }
        #endregion

        #region GetAllFutureEvents
        public IQueryable<Event> GetAllFutureEvents(int lanId)
        {
            IOrderedQueryable<Event> x =
                _aauEnt.Event.Where(s => s.LANID == lanId && s.EndTime >= DateTime.Now && s.FoodID == null).OrderBy(
                    s => s.StartTime);

            return x;
        }
        #endregion

        #region GetAllEvents

        public IQueryable<Event> GetAllEvents()
        {
            return _aauEnt.Event;
        }

        #endregion

        #region GetAllOrders

        public IQueryable<Mad> GetAllOrders()
        {
            return _aauEnt.Mad;
        }

        #endregion

        #region GetAllOrdersWithId

        public IQueryable<Mad> GetAllOrdersWithId(int id)
        {
            return from e in GetAllOrders()
                   where e.EVENTID == id
                   select e;
        }

        #endregion

        #region GetAllLans

        public IQueryable<LAN> GetAllLans()
        {
            return _aauEnt.LAN;
        }

        #endregion

        #region GetAllGames

        public IQueryable<Games> GetAllGames()
        {
            return _aauEnt.Games;
        }

        #endregion

        #region GetAllSeatingPlans

        public IQueryable<SeatingPlan> GetAllSeatingPlans()
        {
            return _aauEnt.SeatingPlan;
        }

        #endregion

        #region GetAllPizzas

        public IQueryable<Pizza> GetAllPizzas()
        {
            return _aauEnt.PizzaSet;
        }

        #endregion

        #region UserHasSeat

        public bool UserHasSeat(string username)
        {
            var x = GetSeatingPlanFromLanId(GetCurrentLan().ID).Seats.FirstOrDefault(s => s.User != null && s.User.Username.Trim() == username.Trim());
            return x != null;
        }

        #endregion

        #endregion

        #region ADD

        #region AddOrder

        public bool AddOrder(Mad mad)
        {
            //Find last id
            Mad idmad = _aauEnt.Mad.Where(s => s.ID > 0).OrderByDescending(s => s.ID).FirstOrDefault();
            if (idmad == null)
            {
                mad.ID = 1;
            }
            else
            {
                mad.ID = idmad.ID;
                mad.ID++;
            }
            try
            {
                Event currentEvent = GetCurrentPizzaEvent();
                if (currentEvent.FoodID != null)
                    mad.EVENTID = (int) currentEvent.FoodID;
                else
                    return false;
            }
            catch
            {
                return false;
            }

            _aauEnt.AddToMad(mad);
            Save();
            return true;
        }

        #endregion

        #region AddLan

        public bool AddLan(LAN lan)
        {
            //Find last id
            LAN idlan = _aauEnt.LAN.Where(s => s.ID > 0).OrderByDescending(s => s.ID).FirstOrDefault();
            lan.ID = idlan == null ? 1 : idlan.ID + 1;

            _aauEnt.AddToLAN(lan);
            var seating = new SeatingPlan {LANID = lan.ID};
            SeatingPlan idseatingplan =
                _aauEnt.SeatingPlan.Where(s => s.Id > 0).OrderByDescending(s => s.Id).FirstOrDefault();
            if (idseatingplan == null)
            {
                seating.Id = 1;
            }
            else
            {
                seating.Id = idseatingplan.Id;
                seating.Id++;
            }
            _aauEnt.AddToSeatingPlan(seating);

            Save();
            return true;
        }

        #endregion

        #region AddSeatingPlan

        public bool AddSeatingPlan(SeatingPlan seatingPlan)
        {
            //Find last id
            SeatingPlan idSeatingPlan =
                _aauEnt.SeatingPlan.Where(s => s.Id > 0).OrderByDescending(s => s.Id).FirstOrDefault();
            if (idSeatingPlan == null)
            {
                seatingPlan.Id = 1;
            }
            else
            {
                seatingPlan.Id = idSeatingPlan.Id;
                seatingPlan.Id++;
            }

            _aauEnt.AddToSeatingPlan(seatingPlan);
            Save();
            return true;
        }

        #endregion

        #region AddSeat

        public bool AddSeat(Seat seat)
        {
            //Find last id
            Seat idSeat = _aauEnt.Seat.Where(s => s.Id > 0).OrderByDescending(s => s.Id).FirstOrDefault();
            if (idSeat == null)
            {
                seat.Id = 1;
            }
            else
            {
                seat.Id = idSeat.Id;
                seat.Id++;
            }

            _aauEnt.AddToSeat(seat);
            Save();
            return true;
        }

        #endregion

        #region AddEvent

        public bool AddEvent(Event event1)
        {
            //Find last id
            Event idevent = _aauEnt.Event.Where(s => s.ID > 0).OrderByDescending(s => s.ID).FirstOrDefault();
            if (idevent == null)
            {
                event1.ID = 1;
            }
            else
            {
                event1.ID = idevent.ID;
                event1.ID++;
            }

            _aauEnt.AddToEvent(event1);
            Save();
            return true;
        }

        #endregion

        #region AddGame

        public bool AddGame(Games game)
        {
            //Find last id
            Games idgame = _aauEnt.Games.Where(s => s.ID > 0).OrderByDescending(s => s.ID).FirstOrDefault();
            if (idgame == null)
            {
                game.ID = 1;
            }
            else
            {
                game.ID = idgame.ID;
                game.ID++;
            }

            _aauEnt.AddToGames(game);
            Save();
            return true;
        }

        #endregion

        #region AddPizza

        public void AddPizza(Pizza pizza)
        {
            //Add user
            _aauEnt.AddToPizzaSet(pizza);

            //Save database
            Save();
        }

        #endregion

        #region AddUser

        /// <summary>
        /// Add user to the database
        /// </summary>
        /// <param name="user">User wich will be added</param>
        public void AddUser(User user)
        {
            //Add user
            _aauEnt.AddToUser(user);

            //Save database
            Save();
        }

        #endregion

        #region AddTeam

        public void AddTeam(Team team)
        {
            _aauEnt.AddToTeamSet(team);
            Save();
        }

        #endregion

        #region AddTeamMember

        public void AddTeamMember(TeamMember teamMember)
        {
            _aauEnt.AddToTeamMemberSet(teamMember);
            Save();
        }

        #endregion

        #region AddTeamMemberToTeam
        public void AddTeamMemberToTeam(Team team, TeamMember teamMember)
        {
            var getTeam = _aauEnt.TeamSet.FirstOrDefault(s => s.Id == team.Id);
            if (getTeam != null) getTeam.TeamMember.Add(teamMember);
            Save();
        }
        #endregion

        #region AddTeamToEvent
        public void AddTeamToEvent(Team team, Event eEvent)
        {
            var getTeam = _aauEnt.TeamSet.FirstOrDefault(s => s.Id == team.Id);
            var getEvent = _aauEnt.Event.FirstOrDefault(s => s.ID == eEvent.ID);
            if (getEvent != null) getEvent.Team.Add(getTeam);
            Save();

        }
        #endregion

        #endregion

        #region DELETE

        #region DeleteOrder

        public void DeleteOrder(int id)
        {
            Mad madobject = _aauEnt.Mad.FirstOrDefault(s => s.ID == id);
            _aauEnt.DeleteObject(madobject);
            Save();
        }

        #endregion

        #region DeleteEvent

        public void DeleteEvent(int id)
        {
            Event eventobject = _aauEnt.Event.FirstOrDefault(s => s.ID == id);
            _aauEnt.DeleteObject(eventobject);
            Save();
        }

        #endregion

        #region DeleteLan

        public void DeleteLan(int id)
        {
            LAN lanobject = _aauEnt.LAN.FirstOrDefault(s => s.ID == id);
            _aauEnt.DeleteObject(lanobject);
            Save();
        }

        #endregion

        #region DeleteUser

        public void DeleteUser(string userName)
        {
            User user = _aauEnt.User.FirstOrDefault(s => s.Username == userName);
            _aauEnt.DeleteObject(user);
            Save();
        }

        #endregion

        #region DeleteSeatingPlan

        public void DeleteSeatingPlan(int id)
        {
            SeatingPlan seatingPlanObject = _aauEnt.SeatingPlan.FirstOrDefault(s => s.Id == id);
            _aauEnt.DeleteObject(seatingPlanObject);
            Save();
        }

        #endregion

        #region DeleteSeat

        public void DeleteSeat(int id)
        {
            Seat seatObject = _aauEnt.Seat.FirstOrDefault(s => s.Id == id);
            _aauEnt.DeleteObject(seatObject);
            Save();
        }

        #endregion

        #endregion

        #region UPDATE

        #region UpdateOrders

        public void UpdateOrders(List<Mad> orders)
        {
            foreach (Mad i in orders)
            {
                Mad m1 = _aauEnt.Mad.FirstOrDefault(s => s.ID == (i.ID));
                if (m1 != null) m1.Paid = i.Paid;
                Save();
            }
        }

        #endregion

        #region UpdateSeats

        public void UpdateSeat(Seat seat)
        {
            Seat m1 = _aauEnt.Seat.FirstOrDefault(s => s.Id == seat.Id);
            if (m1 != null) m1.Taken = seat.Taken;
            Save();
        }

        public void UpdateSeat(Seat seat, User user)
        {
            Seat m1 = _aauEnt.Seat.FirstOrDefault(s => s.Id == seat.Id);
            if (m1 != null)
            {
                m1.Taken = seat.Taken;
                m1.User = user;
            }
            Save();
        }

        #endregion

        #region UpdateSeats

        public void UpdateSeats(List<Seat> seats)
        {
            foreach (Seat i in seats)
            {
                Seat m1 = _aauEnt.Seat.FirstOrDefault(s => s.Id == (i.Id));
                if (m1 != null) m1.Taken = i.Taken;
                Save();
            }
        }

        #endregion

        #region UpdateUser

        public void UpdateUser(User user)
        {
#pragma warning disable 219
            User u1 = _aauEnt.User.FirstOrDefault(s => s.Username == user.Username);
#pragma warning restore 219
            // ReSharper disable RedundantAssignment
            u1 = user;
            // ReSharper restore RedundantAssignment
            Save();
        }

        #endregion

        #endregion

        #region USER

        #region User

        #region GetAllUsers

        /// <summary>
        /// Get all users from database
        /// </summary>
        /// <returns>All users</returns>
        public IQueryable<User> GetAllUsers()
        {
            return _aauEnt.User;
        }

        #endregion

        #endregion

        #region User Validation

        #region GetUserRoleFromUsername

        /// <summary>
        /// Get the userrole from the username
        /// </summary>
        /// <param name="username">Username of user</param>
        /// <returns>User role of user</returns>
        public string GetUserRoleFromUsername(string username)
        {
            User firstOrDefault = _aauEnt.User.FirstOrDefault(d => d.Username == username);
            return firstOrDefault != null ? firstOrDefault.Role : null;
        }

        #endregion

        #region GetUserFromUsername

        public User GetUserFromUsername(string username)
        {
            return _aauEnt.User.FirstOrDefault(d => d.Username == username);
        }

        #endregion

        #region Promote

        public void Promote(string username)
        {
            User user = GetUserFromUsername(username);
            switch (user.Role.Trim())
            {
                case "User":
                    user.Role = "Crew";
                    break;
                case "Crew":
                    user.Role = "Administrator";
                    break;
            }
            Save();
        }

        #endregion

        #region Demote

        public void Demote(string username)
        {
            User user = GetUserFromUsername(username);
            switch (user.Role.Trim())
            {
                case "Administrator":
                    user.Role = "Crew";
                    break;
                case "Crew":
                    user.Role = "User";
                    break;
            }
            Save();
        }

        #endregion

        #region ValidateUser

        /// <summary>
        /// Validate the user with the database
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Encrypted password</param>
        /// <returns>State of user. True if valid</returns>
        public bool ValidateUser(string username, string password)
        {
            //Declare user to validate
            User validateUser = _aauEnt.User.FirstOrDefault(d => d.Username == username);

            //Validate Username
            if (validateUser == null)
            {
                return false;
            }

            //Validate passwords and return
            return password.Trim() == validateUser.Password.Trim();
        }

        #endregion

        #region GetUsersByUsername

        /// <summary>
        /// Get all the users matching the username search text
        /// </summary>
        /// <param name="username">Username to search for</param>
        /// <returns>Matching Users</returns>
        public IQueryable<User> GetUsersByUsername(string username)
        {
            return from e in GetAllUsers()
                   where e.Username.ToLower().Contains(username.ToLower())
                   select e;
        }

        #endregion

        #endregion

        #endregion

        #region SAVE

        #region Save

        public void Save()
        {
            _aauEnt.SaveChanges();
        }

        #endregion

        #endregion
    }
}