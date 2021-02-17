using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_EarlyBinding
{
    
        public class MainClass
        {
            private static void Main()
            {
                Customer C1 = new Customer();
                string fullName = C1.GetFullName("Pragim", "Tech");
                Console.WriteLine("Full Name = {0}", fullName);
            }
        }
        public class Customer
        {
            public string GetFullName(string FirstName, string LastName)
            {
                return FirstName + " " + LastName;
            }
        }
    }

    

