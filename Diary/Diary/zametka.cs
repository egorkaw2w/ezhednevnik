using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    internal class zametka
    {
        string name;
        string desc;
        DateTime date;
        public static DateTime ResetTimeToStartOfDay(DateTime dateTime)
        {
            return new DateTime(
               dateTime.Year,
               dateTime.Month,
               dateTime.Day,
               0, 0, 0, 0);
        }

        static public void getZametka(zametka n)
        {
            Console.WriteLine("----------");
            Console.WriteLine(n.name + "\t " + n.date);
            Console.WriteLine("----------");
            Console.WriteLine(n.desc);
        }
        static public void NameGet( zametka n)
        {
            Console.WriteLine("  " + n.name +"\t"+ n.date.ToString("t"));
        } 
        static public zametka SetZametka(string name, string desc,DateTime date,int hour, int minute)
        {
            zametka NovayaZametka = new zametka();
            NovayaZametka.name = name;
            NovayaZametka.desc = desc;
            NovayaZametka.date = ResetTimeToStartOfDay(date);
            NovayaZametka.date =  NovayaZametka.date.AddHours(hour);
            NovayaZametka.date = NovayaZametka.date.AddMinutes(minute);

            return NovayaZametka;


        }
    }
}
