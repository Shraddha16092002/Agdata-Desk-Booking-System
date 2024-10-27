using System;
using System.Globalization;

namespace AgdataDeskBooking
{
    public class User
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public User(string employeeId, string employeeName)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
        }
        public static void ChooseEmployee(SeatSystem seatsystem, Seat seatobj)
        {
            string employeeId, employeeName;
            Console.WriteLine("Enter Employee Id");
            employeeId = Console.ReadLine();
            if (!seatsystem.EmpAlreadyExists(employeeId))
            {
                Console.WriteLine("Enter Employee Name");
                employeeName = Console.ReadLine();
                seatsystem.employeeList.Add(new User(employeeId, employeeName));
            }
            bool continueEmp = true;
            while (continueEmp)
            {
                Console.WriteLine("1. Book seat\t 2. Cancel seat \t3. View Available seats \t4. Exit");
                int choice = int.Parse(Console.ReadLine());
                int checkid;

                switch (choice)
                {

                    case 1:
                        Console.WriteLine("Enter Seat Id");
                        checkid = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Date");
                        DateTime userDate = DateTime.ParseExact(Console.ReadLine(), "dd-mm-yyyy", CultureInfo.InvariantCulture);
                        if (seatobj.SeatAvailable(checkid, userDate))
                        {
                            Console.WriteLine("Seat booked!");
                            seatsystem.bookList.Add(new Booking(employeeId, checkid, userDate));
                        }
                        else
                        {
                            Console.WriteLine("Seat Not Available!");
                        }

                        break;
                    case 2:
                        Console.WriteLine("Enter Seat Id");
                        int seatid = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Date");
                        DateTime checkDate = DateTime.ParseExact(Console.ReadLine(), "dd-mm-yyyy", CultureInfo.InvariantCulture);

                        if (Booking.IsEmployeeSeat(employeeId, seatid, checkDate, seatsystem))
                        {
                            Console.WriteLine("Seat Cancellation Successful!");
                        }
                        else
                        {
                            Console.WriteLine("No booking details found for specified date!");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter Date");
                        checkDate = DateTime.ParseExact(Console.ReadLine(), "dd-mm-yyyy", CultureInfo.InvariantCulture);
                        seatsystem.ViewAllSeats(checkDate);
                        break;
                    case 4:
                        continueEmp = false;
                        break;
                    default:
                        break;

                }
            }
        }
    }
}
