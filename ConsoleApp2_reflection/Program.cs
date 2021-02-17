using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp2_reflection
{
    public class MainClass
    {
        private static void Main()
        {
            // Get the Type Using GetType() static method
            Type T = Type.GetType("ConsoleApp2_reflection.Customer");
            // Print the Type details
            Console.WriteLine("Full Name = {0}", T.FullName);
            Console.WriteLine("Just the Class Name = {0}", T.Name);
            Console.WriteLine("Just the Namespace = {0}", T.Namespace);
            Console.WriteLine();
            // Print the list of Methods
            Console.WriteLine("Methods in Customer Class");
            MethodInfo[] methods = T.GetMethods();
            foreach (MethodInfo method in methods)
            {
                // Print the Return type and the name of the method
                Console.WriteLine(method.ReturnType.Name + " " + method.Name);
            }
            Console.WriteLine();
            //  Print the Properties
            Console.WriteLine("Properties in Customer Class");
            PropertyInfo[] properties = T.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                // Print the property type and the name of the property
                Console.WriteLine(property.PropertyType.Name + " " + property.Name);
            }
            Console.WriteLine();
            //  Print the Constructors
            Console.WriteLine("Constructors in Customer Class");
            ConstructorInfo[] constructors = T.GetConstructors();



            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor.ToString());
            }
            Console.Read();
        }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Customer(int ID, string Name)
        {
            this.Id = ID;
            this.Name = Name;
        }


        public Customer()
        {
            this.Id = -1;
            this.Name = string.Empty;
        }


        public void PrintID()
        {
            Console.WriteLine("ID = {0}", this.Id);
        }
        public void PrintName()
        {
            Console.WriteLine("Name = {0}", this.Name);
        }
    }
}


////In this example to get the type of customer class we have used GetType() static method defined on the Type class. We pass in the fully qualified name of the type including the namespace as a parameter to the GetType() method.
////Type T = Type.GetType("Pragim.Customer");


//To get the type information we have the following 2 ways as well.
//Use typeof keyowrd
////Type T = typeof(Customer);


//Use GetType() on the instance of the customer class. 
//Customer C1 = new Customer();
////Type T = C1.GetType();


//To get the methods information, we use Type.GetMethods(), which returns MethodInfo[] array and along the same lines we use Type.GetProperties() to get properties information, but Type.GetProperties() returns PropertyInfo[] array.
    
