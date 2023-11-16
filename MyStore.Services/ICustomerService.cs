using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer>GetCustomers(int page);
        IEnumerable<Customer> GetCustomers(int page, string? text);
        Customer? GetCustomer(int id);
        Customer InsertNew(Customer customer);
        bool IsDuplicate(string customerName);
        int Remove(Customer customer);
        Customer Update(Customer customer); 


    }
}
