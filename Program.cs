using System;

namespace Calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    Calendar();
                    break;
                case 1:
                    Calendar(args[0]);
                    break;
                case 2:
                    Calendar(args[0], Convert.ToInt32(args[1]));
                    break;
            }

        }

        public static void Calendar(string month, int year)
        {
            string dateinString = "1" + month + year;
            DateTime date;
            bool success = DateTime.TryParse(dateinString, out date);
            if (success)
            {
                ShowCalendar(date);
            }
            else
            {
                Console.WriteLine("Invalid data");
            }

        }
        public static void Calendar()
        {
            string dateinString = "1" + "." + DateTime.Now.Month + "." + DateTime.Now.Year;
            DateTime date;
            bool success = DateTime.TryParse(dateinString, out date);
            if (success)
            {
                ShowCalendar(date);
            }
            else
            {
                Console.WriteLine("Invalid data");
            }
        }
        public static void Calendar(string month)
        {
            string dateinString = "1" + month + DateTime.Now.Year;
            DateTime date;
            bool success = DateTime.TryParse(dateinString, out date);
            if (success)
            {
                ShowCalendar(date);
            }
            else
            {
                Console.WriteLine("Invalid data");
            }
        }

        public static void ShowCalendar(DateTime startDay)
        {
            Console.WriteLine(startDay.ToString("MMM yyyy"));
            DateTime endDay = startDay.AddMonths(1);
            Console.WriteLine("Sun\tMon\tTu\tWe\tTh\tFr\tSa");
            int emptySpaces = Convert.ToInt32(startDay.DayOfWeek);
            for (int i = 0; i < emptySpaces; i++)
            {
                Console.Write("\t");
            }
            for (var date = startDay; date != endDay; date = date.AddDays(1))
            {
                if (isDaySpecial(date))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write(date.Day + "\t");
                if (date.DayOfWeek == DayOfWeek.Saturday)
                {
                    Console.WriteLine();

                }

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static bool isDaySpecial(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday || date.Date == DateTime.Today)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isDayHoliday(DateTime date, DateTime[] holidays)
        { // in case we need to outline holidays in calendar

            if (Array.Exists(holidays, element => element == date))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
