using System;
using System.Collections.Generic;

namespace AgdataDeskBooking
{
    public class SeatSystem
    {

        public List<Seat> seatList = new List<Seat>();
        public List<Admin> adminList = new List<Admin>();
        public List<User> employeeList = new List<User>();
        public List<Booking> bookList = new List<Booking>();
        public bool AdminAlreadyExists(string id)
        {
            foreach (Admin admin in adminList)
            {
                if (admin.AdminId == id)
                {
                    return true;
                }

            }
            return false;
        }
        public bool EmpAlreadyExists(string id)
        {
            foreach (User emp in employeeList)
            {
                if (emp.EmployeeId == id)
                {
                    return true;
                }

            }
            return false;
        }
        public void ViewAllSeats(DateTime checkDate)
        {

            foreach (Seat seat in seatList)
            {
                List<Booking> bookings = bookList.FindAll(s => s.SeatId == seat.SeatId);
                
                bool isBookedOnDate = bookings.Exists(b => b.UserDate == checkDate);
                if (isBookedOnDate)
                {
                    Console.WriteLine($"Seat Id: {seat.SeatId} \t Availability: False");
                }
                else
                {
                    Console.WriteLine($"Seat Id: {seat.SeatId} \t Availability: True");
                }
            }
        }
        public void ViewSeatDetails()
        {
            Console.WriteLine("Seats in Office: ");
            foreach (Seat seat in seatList)
            {
                Console.WriteLine($"Seat {seat.SeatId}");
            }
            if (bookList.Count == 0)
            {
                Console.WriteLine("No bookings have been made yet");
            }
            else
            {
                Console.WriteLine("Booking Details:");
                foreach (Booking book in bookList)
                {
                    Console.WriteLine($"Seat {book.SeatId}: Booked by Employee {book.EmployeeId} on {book.UserDate?.ToString("yyyy-MM-dd")}");
                }
            }
            
        }
    }
}
