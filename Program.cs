using System;

namespace Calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string command = Console.ReadLine();
                string[] lineValues = command.Split(' ');
                if (lineValues[0] == "calendar")
                {
                    switch (lineValues.Length)
                    {
                        case 1:
                            Calendar();
                            break;
                        case 2:
                            Calendar(lineValues[1]);
                            break;
                        case 3:
                            Calendar(lineValues[1], Convert.ToInt32(lineValues[2]));
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, wrong command");
                }
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
