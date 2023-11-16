using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees(int page);
        IEnumerable<Employee> GetEmployees(int page, string? text);
        Employee? GetEmployee(int id);
        Employee InsertNew(Employee category);
        bool IsDuplicate(string Categoryname);
        int Remove(Employee category);
        Employee Update(Employee category);
    }
}
