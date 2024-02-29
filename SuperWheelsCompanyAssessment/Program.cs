using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperWheelsCompanyAssessment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int numberOfVehiclesSold = 0;
            int soldToRetail = 0;
            int soldToCorp = 0;
            int vehichlesSold = 0;

            Month april = new Month { Name="April", Days = 30 };
            Month may = new Month { Name = "May", Days = 31 };
            Month june = new Month { Name = "June", Days = 30 };
            Month july = new Month { Name = "July", Days = 31 };
            Month august = new Month { Name = "August", Days = 31 };
            Month sept = new Month { Name = "September", Days = 30 };

            List<Month> list = new List<Month>();
            list.Add( april );
            list.Add( may );
            list.Add( june );
            list.Add( july );
            list.Add( august );
            list.Add( sept );

            foreach( Month month in list )
            {
                numberOfVehiclesSold += month.getTotalSold();
            }
            Console.WriteLine("Total sales from April 1st to Sept 30th is: " +  numberOfVehiclesSold);
            Console.WriteLine();

            Console.WriteLine("Number of Vehicles sold each month: ");
            foreach(Month month in list )
            {
                Console.WriteLine("month: " + month.Name + "\tsold: " + month.getTotalSold());
            }
            Console.WriteLine();
                        
            foreach (Month month in list)
            {
                soldToRetail += month.getSoldToRetail();
            }
            Console.WriteLine("Number of Vehicles sold to Retial customers: " + soldToRetail);
            Console.WriteLine();

            foreach (Month month in list)
            {
                soldToCorp += month.getSoldToCorp();
            }
            Console.WriteLine("Number of Vehicles sold to corporate customers: " + soldToCorp);
            Console.WriteLine();

            vehichlesSold = august.getSoldFrom(15, 31) + sept.getSoldFrom(1,15) - 1;
            Console.WriteLine("Number of Vehicles sold from Aug 15th to Sep 15th: " + vehichlesSold);
        }

        public class Month
        {
            public string Name { get; set; }
            public int Days { get; set; }

            public int getSoldToRetail()
            {
                int total = 1;
                int sold = 1;
                int inc = 2;
                for(int i = 2; i<=Days; i++)
                {
                    sold += inc;
                    inc += 2;
                    if (i % 5 != 0)
                    {
                        total += sold;
                    }
                }
                return total;
            }
            public int getSoldToCorp()
            {
                int total = 0;
                int sold = 1;
                int inc = 2;
                for (int i = 2; i <= Days; i++)
                {
                    sold += inc;
                    inc += 2;
                    if (i % 5 == 0)
                    {
                        total += sold;
                    }
                }
                return total;
            }

            public int getTotalSold()
            {
                return getSoldToCorp() + getSoldToRetail();
            }

            public int getSoldFrom(int startDate, int endDate)
            {
                int total = 0;
                int sold = 1;
                int inc = 2;
                for (int i = 2; i <= Days; i++)
                {
                    if(i <= startDate && i<= endDate)
                    {
                        sold += inc;
                        inc += 2;
                        total += sold;
                    }
                }
                return total;
            }
        }
    }
}
