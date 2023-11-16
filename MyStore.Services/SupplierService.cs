using MyStore.Data;
using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class SupplierService : ISupplierService
    {

        private readonly ISupplierRepository supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public Supplier? GetSupplier(int id)
        {
            var existingSupplier = supplierRepository.GetSupplierById(id);
            return existingSupplier;
        }

        public IEnumerable<Supplier>GetSuppliers(int page)
        {
            return supplierRepository.GetAll(page);

        }

        public IEnumerable<Supplier> GetSuppliers(int page, string text)
        {
            return supplierRepository.GetAll(page, text);
        }

        public Supplier InsertNew (Supplier supplier)
        {
            return supplierRepository.Add(supplier);
        }

        public int Remove(Supplier supplier)
        {
            return supplierRepository.Delete(supplier);
        }

        public Supplier Update(Supplier supplier)
        {
            return supplierRepository.Update(supplier);
        }

        public bool IsDuplicate(string Companyname)
        {
            var suppliers = supplierRepository.GetAll();
            suppliers = suppliers.Where(x => x.Companyname==Companyname);
            suppliers.Where(x => x.Companyname.Contains("x"));

            // de verificat ce field - supplier e empty 

            return suppliers.Any();
        }


    }
}
