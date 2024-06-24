using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the customer's name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter last month's water meter readings: ");
            int Watermasslastmonth = GetMeterReading();
            Console.Write("Enter this month's water meter readings: ");
            int Waterblockthismonth = GetMeterReading();
            while ( Waterblockthismonth < Watermasslastmonth)
            {
                Console.Write("Please re-enter this month's water meter readings: ");
                Waterblockthismonth = GetMeterReading();
            }
            int customertype = GetCustomertype();        
            int numberOfPeople = 0;
            if (customertype == 1)
            {
                numberOfPeople = GetNumberOfPeople();
            }
            int consumption = Waterblockthismonth - Watermasslastmonth;
            double amount = CalculateWaterBill(consumption, customertype, numberOfPeople);
            Console.WriteLine("-------------Your waterbill--------------");
            Console.WriteLine("Customer name: " + customerName);
            Console.WriteLine("Last month's water meter readings: " + Watermasslastmonth);
            Console.WriteLine("This month's water meter readings: " + Waterblockthismonth);
            Console.WriteLine("Amount of water consumed: " + consumption + " m3");
            Console.WriteLine("Total amount payable: " + amount + " VND");           
        }

        static int GetMeterReading()
        {
            int meterReading;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out meterReading) && meterReading > 0)
                {
                    return meterReading;
                }
                Console.Write("Please re-enter meter reading: ");
            }
        }

        static int GetCustomertype()
        {
            int customerType;
            Console.WriteLine(" List customer type: ");
            Console.WriteLine(" 1.Family ");
            Console.WriteLine(" 2.Administrative agency ");
            Console.WriteLine(" 3.Production unit ");
            Console.WriteLine(" 4.Business service ");
            Console.Write("Enter customer type: ");
            while (true)
            {             
                if (int.TryParse(Console.ReadLine(), out customerType) && customerType >= 1 && customerType <= 4)
                {
                    return customerType;
                }
                Console.Write("Please re-enter customer type: ");
            }
        }

        static int GetNumberOfPeople()
        {
            int numberOfPeople;
            while (true)
            {
                Console.Write("Enter the number of people in the household: ");
                if (int.TryParse(Console.ReadLine(), out numberOfPeople) && numberOfPeople > 0)
                {
                    return numberOfPeople;
                }
                Console.Write("Please re-enter number of people: ");
            }
        }

        

        static double CalculateWaterBill(int consumption, int customerType, int numberOfPeople)
        {        
            double money = 0;
            switch (customerType)
            {
                case 1:
                    if (consumption <= 10)
                    {
                        money = 5.973 * consumption;
                    }
                    else if (consumption <= 20)
                    {
                        money = 7.052 * (consumption - 10);
                    }
                    else if (consumption <= 30)
                    {
                        money = 8.699 * (consumption - 20);
                    }
                    else
                    {
                        money = 15.929 * (consumption - 30);
                    }
                    break;
                case 2:
                    money = 9.955 * consumption;
                    break;
                case 3:
                    money = 11.615 * consumption;
                    break;
                case 4:
                    money = 22.068 * consumption;
                    break;
            }
            // VAT and EnvỉomentFee
            return money = money * 1.21;
        }              
    }
}
