using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immo.CSharp.Day7
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public interface ICustomerDetails
    {       
        List<Customer> GetCustomerDetails();

        Customer GetCustomer(int ID);
    }

    //ISP 
    public interface IAddCustomer
    {
        int AddCustomer();
    }

    public interface IUpdateCustomer
    {
        int UpdateCustomer();
    }

    public class UpdateCustomerClass : IUpdateCustomer
    {      
        public int UpdateCustomer()
        {
            throw new NotImplementedException();
        }
    }
}
