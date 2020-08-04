using System;

namespace Calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowCalendar(new DateTime(2020,8,1));
           
        }

         public static void ShowCalendar (DateTime wantedDate)
        {
            DateTime startDay = new DateTime(wantedDate.Year, wantedDate.Month, 1);
            DateTime endDay = startDay.AddMonths(1);
            Console.WriteLine("Sun\tMon\tTu\tWe\tTh\tFr\tSa");
            int emptySpaces = Convert.ToInt32(startDay.DayOfWeek);
            for( int i = 0; i < emptySpaces; i++){
                Console.Write("\t");
            }
            int counter = emptySpaces;
            for (var date = startDay; date != endDay; date = date.AddDays(1))
            {   
                
                Console.Write(date.Day + "\t");
                if(counter == 6){
                    Console.WriteLine();
                    counter = 0;
                }
                else{
                    counter++;
                }
            }
               
        }
    }
}
