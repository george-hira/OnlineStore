using MyStore.Data;
using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class ShipperService :IShipperService
    {
        private readonly IShipperRepository shipperRepository;

        public ShipperService(IShipperRepository shipperRepository)
        {
            this.shipperRepository = shipperRepository;
        }


        public Shipper? GetShipper(int id)
        {
            var existingShipper = shipperRepository.GetShipperById(id);
            return existingShipper;
        }


        public IEnumerable<Shipper> GetShippers(int page)
        {

            return shipperRepository.GetAllShippers(page);
        }

        public IEnumerable<Shipper>GetShippers(int page, string text)
        {
            return shipperRepository.GetAllShippers(page, text);

        }

        public Shipper InsertNew(Shipper shipper)
        {

            return shipperRepository.AddShipper(shipper);
        }


        public int Remove(Shipper shipper)
        {
            return shipperRepository.DeleteShipper(shipper);
        }

        public Shipper Update(Shipper shipper)
        {
            return shipperRepository.UpdateShipper(shipper);
        }

        public bool IsDuplicate(string Companyname)
        {
            var shippers = shipperRepository.GetAllShippers();
            shippers = shippers.Where( x => x.Companyname == Companyname);
            shippers.Where(x => x.Companyname.Contains("a"));

            return shippers.Any();  
        }

    }
}

