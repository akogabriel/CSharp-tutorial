public class Row
    {
        public List<Seat> Seats { get; set; }

        public Row()
        {
            Seats = new List<Seat>();
            foreach (SeatLabel label in Enum.GetValues(typeof(SeatLabel)))
            {
                Seats.Add(new Seat(label));
            }
        }
    }