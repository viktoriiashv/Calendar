using System;

namespace Calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            Calendar("July", 2019);
            Calendar("May");
            Calendar();
        }

         public static void Calendar (string month, int year)
        {
            string dateinString = "1" + month + year;
            DateTime date = Convert.ToDateTime(dateinString);
            ShowCalendar(date);
           
        }
        public static void Calendar ()
        {
            string dateinString = "1" + "." + DateTime.Now.Month +"."+ DateTime.Now.Year;
            DateTime date = Convert.ToDateTime(dateinString);
            ShowCalendar(date);
        }
        public static void Calendar (string month)
        {
            string dateinString = "1" + month + DateTime.Now.Year;
            DateTime date = Convert.ToDateTime(dateinString);
            ShowCalendar(date);
        }

        public static void ShowCalendar(DateTime startDay){
            Console.WriteLine(startDay.Month + " " + startDay.Year);
            DateTime endDay = startDay.AddMonths(1);
            Console.WriteLine("Sun\tMon\tTu\tWe\tTh\tFr\tSa");
            int emptySpaces = Convert.ToInt32(startDay.DayOfWeek);
            for( int i = 0; i < emptySpaces; i++){
                Console.Write("\t");
            }
            for (var date = startDay; date != endDay; date = date.AddDays(1))
            {   
                if(date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday || date.Date == DateTime.Today)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write(date.Day + "\t");
                if(date.DayOfWeek == DayOfWeek.Saturday){
                    Console.WriteLine();
                    
                }
              
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
