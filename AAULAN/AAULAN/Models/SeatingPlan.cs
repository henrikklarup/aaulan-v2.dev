using System.Collections.Generic;
using System.Linq;

namespace AAULAN.Models
{
    public partial class SeatingPlan
    {
        readonly DatabaseReposity _repo = new DatabaseReposity();
        public List<Seat> Seats
        {
            get { return _repo.GetSeatsInSeatingPlan(Id).ToList(); }
        }
    }
}
