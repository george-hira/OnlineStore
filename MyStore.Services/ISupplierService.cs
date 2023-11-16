using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface ISupplierService
    {
        IEnumerable<Supplier>GetSuppliers(int page);

        IEnumerable<Supplier> GetSuppliers(int page, string? text);

        Supplier? GetSupplier(int id);

        Supplier InsertNew(Supplier supplier);

        bool IsDuplicate(string Companyname);

        int Remove (Supplier supplier);

        Supplier Update (Supplier supplier);

    }
}
