using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immo.CSharp.Day7
{
    /*
     * Single Responsibility Principle (SRP):
        A class should have only one reason to change, meaning it should have only one job or responsibility.
     */
    public class Employee_SRP
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string MobileNo { get; set; }

        public void GetEmployee()
        {
            try
            {
                Console.WriteLine("Enter Employee Id");
                EmployeeId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Name :");
                EmployeeName = Console.ReadLine();
                Console.WriteLine("Enter Mobile No :");
                MobileNo = Console.ReadLine();
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error :{ex.Message}");
                ExceptionHandler.LogError(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error :{ex.Message}");
                ExceptionHandler.LogError(ex);
            }
        }
    }
}
