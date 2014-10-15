using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vackarklocka
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tester av konstruktorn//
                AlarmClock alarm = new AlarmClock();
                ViewTestHeader("Test 1 \nTest av en standardkonstruktor.\n");
                Console.WriteLine(alarm);


                ViewTestHeader("Test 2 \nTest av konstruktorn med två parametrar.\n");
                alarm = new AlarmClock(9, 42);
                Console.WriteLine(alarm);


                ViewTestHeader("Test 3 \nTest av konstruktorn med fyra parametrar.\n");
                alarm = new AlarmClock(13, 24, 7, 35);
                Console.WriteLine(alarm);


                ViewTestHeader("Test 4 \nStäll ett befintligt AlarmClock-objekt till 23:58 och låter den gå 13 minuter.\n");
                alarm = new AlarmClock(23, 58, 7, 35);
                Run(alarm, 13);


                ViewTestHeader("Test 5 \nStäller befintligt AlarmClock till tiden 6:12 och alarmtiden till 6:15 och låter den gå 6 minuter.\n");
                alarm = new AlarmClock(6, 12, 6, 15);
                Run(alarm, 6);


                ViewTestHeader("Test 6 \nTest av egenskaperna så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.\n");

            //Try catch satser//
            try
            {
                alarm.Hour = 24;
            }
                catch (ArgumentException ex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    ViewErrorMessage("Timmen är inte i intervallet 0-23!");
                    Console.ResetColor();
                }
            try
            {
                alarm.Minute = 60;
            }
                catch (ArgumentException ex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    ViewErrorMessage("Minuten är inte i intervallet 0-59!");
                    Console.ResetColor();
                }
            try
            {
                alarm.AlarmHour = 24;
            }
                catch (ArgumentException ex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    ViewErrorMessage("Timmen är inte i intervallet 0-23!");
                    Console.ResetColor();
                }
            try
            {
                alarm.AlarmMinute = 60;
            }
                catch (ArgumentException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    ViewErrorMessage("Minuten är inte i intervallet 0-59!");
                    Console.ResetColor();
                }

            //Test 7//
            ViewTestHeader("Test 7 \nTest av konstruktorer så att undantag kastas då tid och alarmtid tilldelas felaktig tid.\n");
            try
            {
                alarm = new AlarmClock(24, 60);
            }
                catch (ArgumentException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    ViewErrorMessage("Timmen är inte i intervallet 0-23!");
                    Console.ResetColor();
                }
            try
            {
                alarm = new AlarmClock(24, 60, 24, 60);
            }
                catch (ArgumentException)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    ViewErrorMessage("Minuten är inte i intervallet 0-59!");
                    Console.ResetColor();
                }
        }

        public static void Run(AlarmClock alarm, int minutes)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ---------------------------------------- ");
            Console.WriteLine(" |       Väckarklockan URLED<TM>        | ");
            Console.WriteLine(" |        Modellnr.:1DV402S2L2A         | ");
            Console.WriteLine(" ---------------------------------------- ");
            Console.ResetColor();

            for (int i = 0; i < minutes; i++)
            {
                if (alarm.TickTock())
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(alarm.ToString() + "Beep beep! Wake up!");
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine(alarm.ToString());
                }
            }
        }
        //Error Message//
        private static void ViewErrorMessage(string message)
        {
            Console.WriteLine(message);
        }
        //Headern//
        private static void ViewTestHeader(string header)
        {
            Console.WriteLine(HorizontalLine);
            Console.WriteLine(header);
        }
        //Linje brytningslinken//
        private static string HorizontalLine = "--------------------------------------------------";
    }
}