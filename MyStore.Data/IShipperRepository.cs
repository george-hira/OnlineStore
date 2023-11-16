using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface IShipperRepository
    {
        Shipper AddShipper(Shipper shipper);
        int DeleteShipper(Shipper shipper);
        IEnumerable<Shipper> GetAllShippers(int page);
        IQueryable<Shipper> GetAllShippers();
        IQueryable<Shipper> GetAllShippers(int page, string? text);
        Shipper? GetShipperById(int id);
        Shipper UpdateShipper(Shipper shipper);

    }
}
