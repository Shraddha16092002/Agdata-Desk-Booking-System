using System;

namespace AgdataDeskBooking
{
    class Program
    {
        static void Main(string[] args)
        {
            SeatSystem seatsystem = new SeatSystem();
            Seat seatobj = new Seat(seatsystem);
            Console.WriteLine("\t\tSEATS BOOKING APPLICATION");
            bool app = true;
            while (app)
            {
                Console.WriteLine("Welcome! are you Admin or user? else type Exit \n");

                string userSelection = Console.ReadLine();
                if (userSelection.ToLower() == "exit")
                {
                    Environment.Exit(0);
                }

       
                if (userSelection.ToLower() == "admin")
                {
                    Admin.ChooseAdmin(seatsystem, seatobj);

                }
                else if (userSelection.ToLower() == "user")
                {
                    User.ChooseEmployee(seatsystem, seatobj);

                }
                Console.ReadKey();
            }
        }
    }
}
