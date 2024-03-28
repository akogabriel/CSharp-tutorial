class Program
    {
        static List<Row> seatingChart = new List<Row>();
        static int totalSeats = 0;

        static void Main(string[] args)
        {
            InitializeSeatingChart();

            while (true)
            {
                Console.WriteLine("Please enter 1 to book a ticket.");
                Console.WriteLine("Please enter 2 to see seating chart.");
                Console.WriteLine("Please enter 3 to exit the application.");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    BookTicket();
                }
                else if (input == "2")
                {
                    DisplaySeatingChart();
                }
                else if (input == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
                }
            }
        }

        static void InitializeSeatingChart()
        {
            for (int i = 0; i < 12; i++)
            {
                seatingChart.Add(new Row());
                totalSeats += 4;
            }
        }

        static void BookTicket()
        {
            Console.WriteLine("Please enter the passenger's first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Please enter the passenger's last name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Please enter 1 for a Window seat preference, 2 for an Aisle seat preference, or hit enter to pick first available seat:");
            string seatPreference = Console.ReadLine();

            SeatLabel preferredSeat = SeatLabel.A; // Default seat preference
            if (seatPreference == "1")
            {
                preferredSeat = SeatLabel.A;
            }
            else if (seatPreference == "2")
            {
                preferredSeat = SeatLabel.B;
            }

            Passenger passenger = new Passenger(firstName, lastName, preferredSeat);

            bool seatFound = false;
            foreach (Row row in seatingChart)
            {
                foreach (Seat seat in row.Seats)
                {
                    if (!seat.IsBooked)
                    {
                        if (seat.Label == preferredSeat)
                        {
                            seatFound = true;
                            seat.Passenger = passenger;
                            seat.IsBooked = true;
                            passenger.Seat = seat;
                            break;
                        }
                    }
                }
                if (seatFound) break;
            }

            if (seatFound)
            {
                Console.WriteLine($"The seat located in 1 {passenger.Seat.Label} has been booked.");
            }
            else
            {
                Console.WriteLine("Sorry, the plane is fully booked.");
            }
        }

        static void DisplaySeatingChart()
        {
            foreach (Row row in seatingChart)
            {
                foreach (Seat seat in row.Seats)
                {
                    if (seat.IsBooked)
                    {
                        Console.Write($"{seat.Passenger.FirstName.Substring(0, 1)}{seat.Passenger.LastName.Substring(0, 1)} ");
                    }
                    else
                    {
                        Console.Write($"{seat.Label} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }