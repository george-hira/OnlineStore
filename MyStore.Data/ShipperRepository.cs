using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly StoreContext storeContext;

        public ShipperRepository(StoreContext shipperContext)
        {
            this.storeContext = shipperContext;
        }

        public Shipper? GetShipperById(int id)
        {
            return storeContext.Shippers.Find(id);
        }

        public Shipper AddShipper(Shipper shipper)
        {
            var addedEntity = storeContext.Shippers.Add(shipper).Entity;
            storeContext.SaveChanges();
            return addedEntity;

        }

        public int DeleteShipper(Shipper shipper)
        {
            storeContext.Shippers.Remove(shipper);
            return storeContext.SaveChanges();
        }

        public Shipper UpdateShipper(Shipper shipper)
        {
            var updatedEntity = storeContext.Shippers.Update(shipper).Entity;
            storeContext.SaveChanges();
            return updatedEntity;
        }

        public IEnumerable<Shipper> GetAllShippers(int page) 
        {
            var pageSize = 4;
            var shippers=
                storeContext
                .Shippers
                .Skip(pageSize *(page-1))
                .Take(pageSize)
                .ToList();

            return shippers;
        
        }

        public IQueryable<Shipper>GetAllShippers(int page, string? text)
        {
            var pageSize = 4;
            var shippers = storeContext.Shippers.AsQueryable();

            if (!string.IsNullOrEmpty(text)) 
            {
                shippers = shippers.Where(x => x.Companyname.Contains(text));
            }

            shippers = shippers.Skip(pageSize* (page-1)).Take(pageSize);

            return shippers;
        }

        public IQueryable<Shipper> GetAllShippers()
        {
            return storeContext.Shippers;
        }

        
    }
}
