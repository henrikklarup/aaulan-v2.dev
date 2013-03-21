using System.Collections.Generic;
using System.Drawing;
using AAULAN.Models;

namespace AAULAN.ViewModels
{
    public class SeatingViewModel
    {
        public SeatingPlan SeatingPlan;
        public List<Seat> Seats; 
        public struct DoublePoint
        {
            public Point Coord;
            public Point Dim;
        }

        public List<DoublePoint> MappingTable = new List<DoublePoint>();

        public void MakeSeats()
        {
            //Midtergangen
            var dp = new DoublePoint();
            //TODO: FIX
            dp.Coord = new Point(46, 151);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(46, 189);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(46, 228);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(46, 267);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(46, 307);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(71, 151);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(71, 189);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(71, 228);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(71, 267);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(71, 307);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(113, 151);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(113, 189);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(113, 228);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(113, 267);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(113, 307);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(140, 151);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(140, 189);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(140, 228);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(140, 267);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(140, 307);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(182, 151);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(182, 189);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(182, 228);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(182, 267);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(182, 307);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(208, 151);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(208, 189);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(208, 228);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(208, 267);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            dp.Coord = new Point(208, 307);
            dp.Dim = new Point(21, 33);
            MappingTable.Add(dp);
            //Overste
            dp.Coord = new Point(265, 37);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(305, 37);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(345, 37);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(385, 37);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(423, 37);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(462, 37);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(265, 62);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(305, 62);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(345, 62);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(385, 62);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(423, 62);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(462, 62);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);


            //2. øverste
            dp.Coord = new Point(265, 115);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(305, 115);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(345, 115);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(385, 115);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(423, 115);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(462, 115);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(265, 141);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(305, 141);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(345, 141);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(385, 141);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(423, 141);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(462, 141);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);



            //3 øverste
            dp.Coord = new Point(265, 193);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(305, 193);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(345, 193);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(385, 193);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(423, 193);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(462, 193);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(265, 219);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(305, 219);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(345, 219);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(385, 219);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(423, 219);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(462, 219);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);


            //4. øverste
            dp.Coord = new Point(265, 269);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(305, 269);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(345, 269);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(385, 269);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(423, 269);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(462, 269);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(265, 295);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(305, 295);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(345, 295);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(385, 295);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(423, 295);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(462, 295);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);





            //4 øverste
            dp.Coord = new Point(265, 344);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(305, 344);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(345, 344);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(385, 344);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(423, 344);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(462, 344);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(265, 370);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(305, 370);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(345, 370);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(385, 370);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(423, 370);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);
            dp.Coord = new Point(462, 370);
            dp.Dim = new Point(33, 21);
            MappingTable.Add(dp);


        }
    }
}
