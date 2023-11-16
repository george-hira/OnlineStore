using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public abstract class VehicleFactory
    {

        public abstract IDrivable GetVehicle(VehicleType vehicleType);

       

    }
    // clasa abstracta ne da voie sa avem membri abstracti
    // putem sa avem membri non abstracti => putem sa consideram ca avand o implementare default 
    // care este diferenta dintre o interfata  vs clasa abstracta 


}
