using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly StoreContext storeContext;

        public EmployeeRepository(StoreContext context)
        {
            storeContext = context;
        }

        public Employee Add(Employee employee)
        {
            var addedEntity = storeContext.Employees.Add(employee).Entity;
            storeContext.SaveChanges();
            return addedEntity;
        }

        public int Delete(Employee employee)
        {
            storeContext.Employees.Remove(employee);
            return storeContext.SaveChanges();
        }


        public Employee? GetEmployeeById(int id)
        {
            return storeContext.Employees.Find(id);
        }

        public Employee Update(Employee employee)
        {
            var updatedEntity = storeContext.Employees.Update(employee).Entity;
            storeContext.SaveChanges();
            return updatedEntity;
        }

        public IEnumerable<Employee> GetAll(int page)
        {
            var pageSize = 2;
            var employees =
                 storeContext
                .Employees
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToList();

            return employees;
        }


        public IQueryable<Employee> GetAll(int page, string? text)
        {
            var pageSize = 2;

            var employeess = storeContext.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(text))
            {
                employeess = employeess.Where(x => x.Title.Contains(text));

            }

            employeess = employeess.Skip(pageSize * (page - 1))
                .Take(pageSize);

            return employeess;
        }


        public IQueryable<Employee> GetAll()
        {
            return storeContext.Employees;
        }
    }
}
