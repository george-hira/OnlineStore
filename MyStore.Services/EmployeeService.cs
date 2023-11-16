using MyStore.Data;
using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            this.repository = repository;
        }

        public Employee? GetEmployee(int id)
        {
            return repository.GetEmployeeById(id);
        }

        public IEnumerable<Employee> GetEmployees(int page)
        {
            return repository.GetAll(page);
        }

        public IEnumerable<Employee> GetEmployees(int page, string? text)
        {
            return repository.GetAll(page, text);
        }

        public Employee InsertNew(Employee category)
        {
            return repository.Add(category);
        }

        public bool IsDuplicate(string Categoryname)
        {
            throw new NotImplementedException();
        }

        public int Remove(Employee category)
        {
            return repository.Delete(category);
        }

        public Employee Update(Employee category)
        {
            return repository.Update(category);
        }
    }
}
