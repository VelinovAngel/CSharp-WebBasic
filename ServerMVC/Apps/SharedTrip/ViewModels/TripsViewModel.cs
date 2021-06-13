﻿namespace SharedTrip.ViewModels
{
    public class TripsViewModel
    {
        public string Id { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public string DepartureTime { get; set; }

        public string ImagePath { get; set; }

        public int Seats { get; set; }

        public int UsedSeats { get; set; }

        public string Description { get; set; }
    }
}
