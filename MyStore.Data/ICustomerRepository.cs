using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface ICustomerRepository
    {
        Customer Add(Customer customer);
        int Delete(Customer customer);

        IEnumerable<Customer> GetAll(int page);

        IQueryable<Customer> GetAll();

        IQueryable<Customer> GetAll(int page, string? text);

        Customer? GetCustomerById (int id);

        Customer Update (Customer customer);


    }
}
