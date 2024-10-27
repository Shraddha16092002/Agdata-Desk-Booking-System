using System;

namespace AgdataDeskBooking
{
    public class Admin
    {
        public string AdminId { get; set; }
        public string AdminName { get; set; }
        public Admin(string adminId, string adminName)
        {
            AdminId = adminId;
            AdminName = adminName;
        }
        public static void ChooseAdmin(SeatSystem seatsystem, Seat seatobj)
        {
            string adminId, adminName;
            Console.WriteLine("Enter Admin Id");
            adminId = Console.ReadLine();
            if (!seatsystem.AdminAlreadyExists(adminId))
            {
                Console.WriteLine("Enter Admin Name");
                adminName = Console.ReadLine();
                seatsystem.adminList.Add(new Admin(adminId, adminName));
            }
            bool continueAdmin = true;
            while (continueAdmin)
            {
                Console.WriteLine("1. Add seat\t 2. Remove seat \t 3. view all seats \t4. Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Seat Id");
                        seatobj.SeatId = int.Parse(Console.ReadLine());
                        seatobj.AddSeat();
                        Console.WriteLine("Seat Added");
                        break;
                    case 2:
                        Console.WriteLine("Enter Seat Id");
                        int seatid = int.Parse(Console.ReadLine());
                        seatobj.RemoveSeat(seatid);
                        Console.WriteLine("Seat Removed");
                        break;
                    case 3:
                        seatsystem.ViewSeatDetails();
                        break;
                    case 4:
                        continueAdmin = false;
                        break;
                    default:
                        break;

                }
            }
        }
    }
}
