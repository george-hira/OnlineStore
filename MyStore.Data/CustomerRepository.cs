using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreContext storeContext;

        public CustomerRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Customer? GetCustomerById(int id)
        {
            return storeContext.Customers.Find(id);
        }

        public Customer Add(Customer customer) 
        { 
            var addedEntity = storeContext.Customers.Add(customer).Entity;
            storeContext.SaveChanges();
            return addedEntity;
        
        }

        public int Delete(Customer customer) 
        {
            storeContext.Customers.Remove(customer);
            return storeContext.SaveChanges();
        }

        public Customer Update(Customer customer) 
        {
            var updatedEntity = storeContext.Customers.Update(customer).Entity;
            storeContext.SaveChanges();
            return updatedEntity;

        }
        public IEnumerable<Customer>GetAll(int page)
        {
            var pageSize = 4;
            var customers = 
                storeContext
                .Customers
                .Skip(pageSize * (page -1))
                .Take(pageSize)
                .ToList();
            return customers;
        }    

        public IQueryable<Customer>GetAll(int page, string? text)
        {
            var pageSize = 3;
            var customers = storeContext.Customers.AsQueryable();

            if(!string.IsNullOrEmpty(text))
            {
                customers = customers.Where(x=> x.Contactname.Contains(text));
            }
            customers = customers.Skip(pageSize * (page - 1))
                .Take(pageSize);

            return customers;
        }

        public IQueryable<Customer> GetAll()
        {
            return storeContext.Customers;
        }
    }
    

    
}
