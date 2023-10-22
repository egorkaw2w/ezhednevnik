using System.Data;

namespace Diary
{
    internal class Program
    {
        public static DateTime day = DateTime.Now;
        static public int Show(int min, List<zametka> k)
        {

            int pos = 1;
            ConsoleKey key;

            do
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");

                key = Console.ReadKey(true).Key;

                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  ");
                if (key == ConsoleKey.DownArrow && pos != k.Count() + 1)
                {
                    pos++;
                }
                else if (key == ConsoleKey.UpArrow && pos != min)
                {
                    pos--;
                }

                else if (key == ConsoleKey.Enter && pos == k.Count + 1)
                {
                    k.Add(zametka.SetZametka(Console.ReadLine(), Console.ReadLine(), day, int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));
                    key = ConsoleKey.F1;
                }
                else if (key == ConsoleKey.Escape)
                {
                    return 100;
                }
                
            } while (key != ConsoleKey.Enter);

            return pos-1;
        }
        static public DateTime SwitchData(DateTime day, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.RightArrow: day = day.AddDays(1); break;
                case ConsoleKey.LeftArrow: day = day.AddDays(-1); break;
            }
            Console.WriteLine(day.ToString("D"));
            return day;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Это - ежедневник");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Упрвление: -> - следующая дата");
            Console.WriteLine("Упрвление: <- - Предыдущая дата");
            Console.WriteLine("Enter - заглянуть в заметку");
            Console.WriteLine("\t" + "При создании заметки пишите:" + "\n" +"Названеи заметки" + "\n" + "описание заметки" + "\n"  + "время ( часы)" + "\n" + "Время (минуты)");

            ConsoleKey key;


            
            Dictionary<DateTime, List<zametka>> spravochink = new Dictionary<DateTime, List<zametka>>();

            zametka z = zametka.SetZametka("first", "ona pervaya", day, 12, 45);
            zametka z1 = zametka.SetZametka("second", "ona  ne pervaya", day, 12, 45);
            zametka z2 = zametka.SetZametka("third", "asdzxc", day, 13, 50);
            zametka z3 = zametka.SetZametka("fourth", "forht asd", day, 21,0);
            zametka z4 = zametka.SetZametka("five", "ona pervaya", day, 15,21);
            zametka z5 = zametka.SetZametka("six", "Получил инсульт, пока делал ежедневник", day, 4, 21);


            spravochink.Add(day, new List<zametka>() { z, z1 } );
            spravochink.Add(day.AddDays(1), new List<zametka>() { z2, z3 } );
            spravochink.Add(day.AddDays(2), new List<zametka>() { z4, z5 } );

            do
            {
                key = Console.ReadKey(true).Key;

                Console.Clear();

                day = SwitchData(day,key);

                if (!spravochink.ContainsKey(day) && key == ConsoleKey.Enter)
                {
                    
                    spravochink  [day] =  new List<zametka>() { (zametka.SetZametka(Console.ReadLine(), Console.ReadLine(), day, int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()))) }  ;
                  
                }

                else if(spravochink.ContainsKey(day) )
                {
                    
                    foreach (var item in spravochink[day])
                    {
   
                        zametka.NameGet(item);
                        
                    }
                    if (key == ConsoleKey.Enter) 
                    {
                        int pos = Show(1, spravochink[day]);
                        if (pos != 100)
                        {
                            Console.Clear();
                            zametka.getZametka(spravochink[day][pos]);
                        }
                    }
               
                    
                }
                 

            } while (true);

            Console.WriteLine();
        }
    }
}