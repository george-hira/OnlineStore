using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface ISupplierRepository
    {
        Supplier Add(Supplier supplier);

        int Delete (Supplier supplier);

        IEnumerable<Supplier> GetAll (int page);

        IQueryable<Supplier> GetAll ();
        IQueryable<Supplier> GetAll(int page, string? text);

        Supplier? GetSupplierById(int id);

        Supplier Update(Supplier supplier);
    }
}
