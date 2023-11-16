using MyStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IShipperService
    {

        IEnumerable<Shipper> GetShippers(int page);
        IEnumerable<Shipper> GetShippers(int page, string? text);
        Shipper? GetShipper(int id);
        Shipper InsertNew(Shipper shipper);
        bool IsDuplicate(string Companyname);
        int Remove(Shipper shipper);
        Shipper Update(Shipper shipper);
        

    }
}
