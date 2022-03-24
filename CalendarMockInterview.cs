//create data structure to represent a calendar

//bool isAvailable(int year, int dayOfyear, int minute, int howmanyminutes)

//bool reserve(int year, int day of year, int minute of day, int how many minutes)



public class Calendar
{
    public List<Reservation> reservations { get; set; }

    public bool isAvailable(Reservation reservationToTry)
    {
        for(int i = 0; i < reservations.Count; i++)
        {

            int endOfReservedTimeslot = reservations[i].startMinute + reservations
            if (reservationToTry.startMinute)
        }





        
    }

}

//year, dayofyear, startminute, howmanyminutes