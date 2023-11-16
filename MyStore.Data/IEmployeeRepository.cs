using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface IEmployeeRepository
    {
        Employee Add(Employee category);
        int Delete(Employee category);
        IEnumerable<Employee> GetAll(int page);
        IQueryable<Employee> GetAll();
        IQueryable<Employee> GetAll(int page, string? text);
        Employee? GetEmployeeById(int id);
        Employee Update(Employee category);
    }
}
