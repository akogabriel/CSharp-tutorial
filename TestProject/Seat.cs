public class Seat
    {
        public bool IsBooked { get; set; }
        public Passenger Passenger { get; set; }
        public SeatLabel Label { get; set; }

        public Seat(SeatLabel label)
        {
            IsBooked = false;
            Passenger = null;
            Label = label;
        }
    }