public class Passenger
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SeatLabel PreferredSeat { get; set; }
        public Seat Seat { get; set; }

        public Passenger(string firstName, string lastName, SeatLabel preferredSeat)
        {
            FirstName = firstName;
            LastName = lastName;
            PreferredSeat = preferredSeat;
            Seat = null;
        }
    }