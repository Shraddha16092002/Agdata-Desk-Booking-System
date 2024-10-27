using System;

namespace AgdataDeskBooking
{
    public class Booking
    {
        public string EmployeeId { get; set; }
        public int SeatId { get; set; }
        public DateTime? UserDate { get; set; }
        public Booking(string Empid, int seatId, DateTime userDate)
        {
            EmployeeId = Empid;
            SeatId = seatId;
            UserDate = userDate;
        }
        public static bool IsEmployeeSeat(string empid, int seatid, DateTime checkDate, SeatSystem seatsystem)
        {
            Booking empSeat = seatsystem.bookList.Find(s => s.EmployeeId == empid && s.SeatId == seatid && s.UserDate == checkDate);

            if (empSeat == null)
            {
                return false;
            }
            seatsystem.bookList.Remove(empSeat);
            return true;
            
        }
    }
}
