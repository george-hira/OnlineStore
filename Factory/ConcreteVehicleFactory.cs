using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    // VehicleFactoryImplementation

    // clasele abstracte se mostenesc / se extind!!!!
    public  class ConcreteVehicleFactory : VehicleFactory
    {
        public override IDrivable GetVehicle(VehicleType vehicleType)


        {
            switch(vehicleType) 
            {
                case VehicleType.Bike   : return new Scooter();

                case VehicleType.Scooter: return new Bike();

                default:
                    throw new ApplicationException($"Vehicle of type {vehicleType} can't be created");
                       
            }
            
        }

        //public void ComputeNecessaryMaterials()
        //{

        //}
    }
}
