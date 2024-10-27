using System;

namespace AgdataDeskBooking
{
    public class Seat
    {
        SeatSystem seatsystem;
        public int SeatId { get; set; }
        
        public Seat(SeatSystem system)
        {
            seatsystem = system;
        }
        public void AddSeat()
        {
            seatsystem.seatList.Add(new Seat(seatsystem) { SeatId = this.SeatId });
           
        }
        public void RemoveSeat(int seatid)
        {
            seatsystem.seatList.RemoveAll(s => s.SeatId == seatid);
        }
        public bool SeatAvailable(int checkid, DateTime userdate)
        {
            Booking book = seatsystem.bookList.Find(s => s.SeatId == checkid && s.UserDate == userdate);
            return book == null;
            
        }
    }
}
