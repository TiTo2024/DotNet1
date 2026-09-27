using System;
using System.Collections;
using System.Collections.Generic;

namespace DotNetElwakeelAssignment
{
    #region Part 3: Extension Methods Helper Class
    public static class ExtensionMethods
    {
        // 6. String Extension Method: IsPalindrome (No LINQ)
        public static bool IsPalindrome(this string str)
        {
            if (string.IsNullOrEmpty(str)) return false;

            int left = 0;
            int right = str.Length - 1;

            while (left < right)
            {
                if (char.ToLower(str[left]) != char.ToLower(str[right]))
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        // 7. Int Extension Method: IsPrime (Loop based)
        public static bool IsPrime(this int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i * i <= number; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // 8. Array Extension Method: Custom Sum (No LINQ)
        public static int CustomSum(this int[] array)
        {
            if (array == null) return 0;

            int total = 0;
            foreach (int item in array)
            {
                total += item;
            }
            return total;
        }
    }
    #endregion

    #region Part 4: Custom Helper Models
    public class Employee
    {
        public string Name { get; set; } = string.Empty;
        public decimal Salary { get; set; }



        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }
    }
    #endregion

    public class Program
    {
        public static void Main(string[] args)
        {


            #region Part 1: Implicitly Typed Local Variables (var)

            // Problem 1: Basic var usage
            Console.WriteLine("--- PART 1: IMPLICITLY TYPED LOCAL VARIABLES ---");

            var age = 42;
            var Name = "Hello C#";
            var Hight = 3.14159;
            var myBool = true;
            var myArray = new int[] { 1, 2, 3, 4, 5 };

            Console.WriteLine($"1. Age Type: {age.GetType()}");
            Console.WriteLine($"   Name Type: {Name.GetType()}");
            Console.WriteLine($"   Height Type: {Hight.GetType()}");
            Console.WriteLine($"   IsTrue Type: {myBool.GetType()}");
            Console.WriteLine($"   Array Type: {myArray.GetType()}\n");

            // Problem 2: var vs Explicit Type
            // Explicit Declarations:
            int count = 10;
            string language = "C#";
            double pi = 3.14;

            // Implicit Declarations using var:
            var countVar = 10;
            var languageVar = "C#";
            var piVar = 3.14;

            /*
             * Explanation (Problem 2):
             * Why is the result exactly the same at compile time?
             * In C#, 'var' is syntactic sugar for type inference. The compiler infers the type of the variable 
             * at compile-time based on the right-hand side expression and bakes the explicit type into the 
             * generated Intermediate Language (CIL). Therefore, both approaches produce identical machine code.
             */
            Console.WriteLine("2. Explicit vs Var demonstrated. (See comments for compile-time explanation)\n");
            #endregion

            #region Part 2: Anonymous Types
            Console.WriteLine("--- PART 2: ANONYMOUS TYPES ---");

            // Problem 3: Anonymous Type Basics
            var product = new { Name = "Laptop", Price = 1200.50m, Quantity = 5 };
            Console.WriteLine($"3. Product: Name={product.Name}, Price={product.Price:C}, Quantity={product.Quantity}");

            // Problem 4: Array of Anonymous Types
            var students = new[]
            {
                new { Name = "Alice", Grade = 92.5, age = 20 },
                new { Name = "Bob", Grade = 85.0, age = 22 },
                new { Name = "Charlie", Grade = 78.0, age = 21 }
            };

            Console.WriteLine("4. Student Array Details:");
            foreach (var student in students)
            {
                Console.WriteLine($"   - Name: {student.Name}, Grade: {student.Grade}, Age: {student.age}");
            }

            // Problem 5: Nested Anonymous Type
            var order = new
            {
                OrderId = 5001,
                OrderDate = DateTime.Now,
                Customer = new { Name = "Mostafa Mahmoud", City = "Cairo" }
            };

            Console.WriteLine($"5. Order ID: {order.OrderId}, Date: {order.OrderDate:yyyy-MM-dd}");
            Console.WriteLine($"   Customer Details: {order.Customer.Name} from {order.Customer.City}\n");
            #endregion

            #region Part 3: Extension Methods
            Console.WriteLine("--- PART 3: EXTENSION METHODS ---");

            // Problem 6: String IsPalindrome
            string test1 = "Readaer";
            string test2 = "Backend";
            Console.WriteLine($"6. Is '{test1}' a Palindrome? {test1.IsPalindrome()}");
            Console.WriteLine($"   Is '{test2}' a Palindrome? {test2.IsPalindrome()}");

            // Problem 7: Int IsPrime
            int num1 = 17;
            int num2 = 20;
            Console.WriteLine($"7. Is {num1} Prime? {num1.IsPrime()}");
            Console.WriteLine($"   Is {num2} Prime? {num2.IsPrime()}");

            // Problem 8: Array Sum (Without LINQ)
            int[] numbers = { 10, 20, 30, 40, 50 };
            Console.WriteLine($"8. Total Sum of Array [{string.Join(", ", numbers)}]: {numbers.CustomSum()}\n");
            #endregion

            #region Part 4: Collections (List, Hashtable, Dictionary)
            Console.WriteLine("--- PART 4: COLLECTIONS ---");

            // Problem 9: List Basics (Add, Remove, Search without LINQ)
            List<string> employees = new List<string> { "Ahmed", "Mostafa", "Sara", "Mona" };
            employees.Add("Omar");

            // Remove using loop
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i] == "Sara")
                {
                    employees.RemoveAt(i);
                    break;
                }
            }

            // Search using loop
            string searchTarget = "Mostafa";
            bool isFound = false;
            foreach (var empName in employees)
            {
                if (empName == searchTarget)
                {
                    isFound = true;
                    break;
                }
            }
            Console.WriteLine($"9. Search for '{searchTarget}': {(isFound ? "Found" : "Not Found")}");
            Console.WriteLine("   Final Employee List:");
            foreach (var name in employees)
            {
                Console.WriteLine($"    * {name}");
            }

            // Problem 10: List of Custom Objects
            List<Employee> empList = new List<Employee>
            {
                new Employee("Alice", 4500m),
                new Employee("Bob", 6200m),
                new Employee("Charlie", 8000m),
                new Employee("Diana", 3500m)
            };

            decimal salaryThreshold = 5000m;
            Console.WriteLine($"\n10. Employees with salary above {salaryThreshold:C}:");
            foreach (var emp in empList)
            {
                if (emp.Salary > salaryThreshold)
                {
                    Console.WriteLine($"    * {emp.Name}: {emp.Salary:C}");
                }
            }

            // Problem 11: Dictionary Basics
            Dictionary<string, int> productPrices = new Dictionary<string, int>
            {
                { "Laptop", 1200 },
                { "Mouse", 25 },
                { "Keyboard", 75 }
            };

            Console.WriteLine("\n11. Product Prices Dictionary:");
            foreach (KeyValuePair<string, int> kvp in productPrices)
            {
                Console.WriteLine($"    * Product: {kvp.Key}, Price: ${kvp.Value}");
            }

            // Problem 12: Dictionary Lookup using TryGetValue
            Dictionary<int, string> studentMap = new Dictionary<int, string>
            {
                { 101, "Mostafa" },
                { 102, "Ali" },
                { 103, "Ayman" }
            };

            int searchId = 1002;
            Console.WriteLine("\n12. Dictionary Lookup:");
            if (studentMap.TryGetValue(searchId, out string? matchedName))
            {
                Console.WriteLine($"    Student ID {searchId} -> Name: {matchedName}");
            }
            else
            {
                Console.WriteLine($"    Student ID {searchId} not found.");
            }

            // Problem 13: Hashtable Basics
            Hashtable hashtable = new Hashtable
            {
                { 1, "First Element" },
                { "KeyTwo", 200 },
                { 3.14, true }
            };

            Console.WriteLine("\n13. Hashtable DictionaryEntries:");
            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine($"    * Key: {item.Key} (Type: {item.Key.GetType().Name}) | Value: {item.Value} (Type: {item.Value?.GetType().Name})");
            }

            // Problem 14: Dictionary vs Hashtable comparison
            Dictionary<string, string> dictData = new Dictionary<string, string>
            {
                { "EG", "Egypt" },
                { "US", "United States" }
            };

            Hashtable hashData = new Hashtable
            {
                { "EG", "Egypt" },
                { "US", "United States" }
            };

            string dictVal = dictData["EG"]; // Strongly typed string
            string hashVal = (string)hashData["EG"]!; // Requires explicit cast from object

            /*
             * Practical Difference (Problem 14):
             * Type Safety & Performance: Dictionary<TKey, TValue> is strongly-typed, preventing runtime type mismatches
             * and eliminating the performance overhead of boxing/unboxing for value types. In contrast, Hashtable stores
             * both keys and values as 'object', requiring explicit casting and introducing risk of runtime cast exceptions.
             */
            Console.WriteLine("\n14. Dictionary vs Hashtable demonstrated. (See comments for practical differences)\n");
            #endregion

        }
    }
}