using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp1_LateBinding
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the current executing assembly as the Customer class is present in it.
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
        // Load the Customer class for which we want to create an instance dynamically
        Type customerType = executingAssembly.GetType("ConsoleApp1_LateBinding.Customer");
        // Create the instance of the customer type using Activator class 
        object customerInstance = Activator.CreateInstance(customerType);
        // Get the method information using the customerType and GetMethod()
        MethodInfo getFullName = customerType.GetMethod("GetFullNames");



        // Create the parameter array and populate first and last names
        string[] methodParameters = new string[2];
        methodParameters[0] = "Pragim"; //FirstName
            methodParameters[1] = "Tech";     //LastName
            // Invoke the method passing in customerInstance and parameters array
            string fullName = (string)getFullName.Invoke(customerInstance, methodParameters);
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


//Let 's assume we don't have the knowledge of Customer class at compile time, and it will be provided only at run time. In this case we need to bind to the Customer class at runtime.
//1.Load the assembly which contains the Customer class. In our case, the Customer class is present in the same assembly as the MainClass. So, we use Assembly.GetExecutingAssembly() to load the current executing assembly. 
//On the Assembly class, there are several static methods which can be used to load an assembly at runtime dynamically.
//2. Next, we load the Customer class for which we want to create an instance dynamically using executingAssembly.GetType("Pragim.Customer"). Make sure you pass in the fully qualified name to the GetType() method, including the namespace.Otherwise you risk getting a NullReferenceException at runtime.
//3. Create the instance of the Customer class using Activator.CreateInstance(customerType).
//4. Once we have the Customer instance, now get the method information which we want to invoke dynamically.we use customerType.GetMethod("GetFullName").

 

//5. The GetFullName() method expects 2 string parameters.So, we need to create a string array, and populate it with the first and last name parameters.
//6. Finally, invoke the method passing in customerInstance and parameters array.


//If you mis-spell the method name or if you pass in the wrong number or type of parameters, you wouldn't get a compiler error, but the application crashes at runtim
//        }
//    }
//}
